﻿import {bootstrap, Component, View, NgFor, NgClass, AfterViewInit, Inject} from 'angular2/angular2';
import {Http, HTTP_BINDINGS, Headers} from 'angular2/http';




@Component({
    selector: 'geekquiz-app',
    viewBindings: [HTTP_BINDINGS]
})
@View({
    directives: [NgFor, NgClass],
    template: `
        <div class="flip-container text-center ">
            <div class="back" [ng-class]="{flip: answered, correct: correctAnswer, incorrect:!correctAnswer}">
                <p class="lead">{{answer()}}</p>
                <p>
                    <button class="btn btn-info btn-lg next option" (click)="nextQuestion()" [disabled]="working">Next Question</button>
                </p>
            </div>
            <div class="front" [ng-class]="{flip: answered}">
                <p class="lead">{{timecount}}</p>
                <p class="lead">{{title}}</p>
                <div class="container text-center">
                    <button class="btn btn-info btn-lg option" *ng-for="#option of options" (click)="sendAnswer(option)" [disabled]="working">{{option.title}}</button>
                </div>
                <div>{{num}}</div>
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
    public timecount=15;
    public timer;
    constructor( @Inject(Http) private http: Http) {
    }

    answer() {
        return this.correctAnswer ? 'correct' : 'incorrect';
    }

    nextQuestion() {
        this.working = true;

        this.answered = false;
        this.title = "loading question...";
        this.options = [];

        var headers = new Headers();
        headers.append('If-Modified-Since', 'Mon, 27 Mar 1972 00:00:00 GMT');

        this.http.get("/Home/gettime", { headers: headers }).map(res => res.json()).subscribe(q => { this.timecount = q.timeperquestion; });
       
        this.timer = setInterval(t => {
            this.timecount--;
            if (this.timecount == 0) {

                this.Timeup();
                clearInterval(this.timer);
            }

        }, 1000);


       
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
    }

    sendAnswer(option) {
        this.working = true;

        clearInterval(this.timer);
        var answer = { 'questionId': option.questionId, 'optionId': option.id };

        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        this.http.post('/api/trivia', JSON.stringify(answer), { headers: headers })
            .map(res => res.json())
            .subscribe(
            answerIsCorrect => {
                this.answered = true;
                this.correctAnswer = (answerIsCorrect === true);
                this.working = false;
            },
            err => {
                this.title = "Oops... something went wrong";
                this.working = false;
            });
    }


    Timeup()
    {
        clearInterval(this.timer);
        this.working = true;
        var answer = { 'questionId': this.options[0].questionId, 'optionId': this.options[0].id,'userId':'wrong' };

        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        this.http.post('/api/trivia/', JSON.stringify(answer), { headers: headers })
            .map(res => res.json())
            .subscribe(
            answerIsCorrect => {
                this.answered = true;
                this.correctAnswer = false;
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