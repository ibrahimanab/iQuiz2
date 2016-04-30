import {bootstrap, Component, View, NgFor, NgClass, AfterViewInit, Inject} from 'angular2/angular2';
import {Http, HTTP_BINDINGS, Headers} from 'angular2/http';

@Component({
    selector: 'geekquiz-app',
    viewBindings: [HTTP_BINDINGS]
})
@View({
    directives: [NgFor, NgClass],
    template: `


        <div class="flip-container text-center col-md-12">
                 
        

            <div class="back" [ng-class]="{flip: answered, correct: correctAnswer, incorrect:!correctAnswer}">
                <p class="lead">{{answer()}}</p>
                <p>
                    <button class="btn btn-info btn-lg next option" (click)="nextQuestion()" [disabled]="working">Next Question</button>
                </p>
            </div>
            <div class="front" [ng-class]="{flip: answered}">
                 <div class="row text-center">{{timecount}}</div> 
                <p class="lead">{{title}}</p>
                <div class="row text-center">
                    <button class="btn btn-info btn-lg option" *ng-for="#option of options" (click)="sendAnswer(option, startTime)" [disabled]="working">{{option.title}}</button>
                </div>

            </div>
        </div>
    `
})
class AppComponent implements AfterViewInit {
    public answered = false;
    public title = "loading question...";
    public options = [];
    public correctAnswer = false;
    public working = false;
    public startTime:Date;
    public endTime: Date;
    private timer;
    public timecount: number; 
    constructor( @Inject(Http) private http: Http) {
    }

    answer() {
        
       
        return this.correctAnswer ? 'correct' : 'incorrect';
    }

    nextQuestion() {

        this.timecount = 60;
        
        this.working = true;
       


        
        this.answered = false;
        this.title = "loading question...";
        this.options = [];
        this.startTime = new Date();
        var headers = new Headers();
        headers.append('If-Modified-Since', 'Mon, 27 Mar 1972 00:00:00 GMT');
        this.http.get("/api/trivia", { headers: headers })
            .map(res => res.json())
            .subscribe(
                question => {
                    this.options = question.options;
                    this.title = question.title;
                    this.answered = false;
                    this.working = false;
                    
                },
                err => {
                    this.title = "Oops... something went wrong";
                    this.working = false;
                });
        this.timer = setInterval(() => {


            if (this.timecount > 0) {
                this.timecount--;


            }
            else {

                
                this.sendAnswer(null, this.startTime);
            }
        }, 1000);

    }

    sendAnswer(option, startTime) {
      
        this.working = true;
        this.endTime = new Date();
        clearInterval(this.timer);
       var result= Number(this.endTime) - Number(startTime);
       
       
       var headers = new Headers();
       headers.append('Content-Type', 'application/json');
       
       if (option == null)
       {
           
           var wanswer = { 'questionId': this.options[0].questionId, 'optionId': this.options[0].id,'userId':"wrong"};
          
           this.http.post('/api/trivia', JSON.stringify(wanswer), { headers: headers })
               .map(res => res.json())
               .subscribe(
               answerIsCorrect => {
                   this.answered = true;
                   this.correctAnswer = true;
                   this.working = false;
               },
               err => {
                   this.title = "Oops... something went wrong";
                   this.working = false;
               });
          

           return;
       }
       var answer = { 'questionId': option.questionId, 'optionId': option.id };
       


       


        this.http.post('/api/trivia', JSON.stringify(answer), { headers: headers })
            .map(res => res.json())
            .subscribe(
            answerIsCorrect => {
                this.answered = true;
                this.correctAnswer =
                    (answerIsCorrect === true);
                this.working = false;
            },
            err => {
                this.title = "Oops... something went wrong";
                this.working = false;
            });


        

        
    }
    
    afterViewInit() {

        this.nextQuestion();

       
    }

   
}

bootstrap(AppComponent);