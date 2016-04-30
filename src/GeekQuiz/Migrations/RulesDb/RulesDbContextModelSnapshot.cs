using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using GeekQuiz.Models;

namespace GeekQuiz.Migrations.RulesDb
{
    [DbContext(typeof(RulesDbContext))]
    partial class RulesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeekQuiz.Models.Rules", b =>
                {
                    b.Property<int>("RulesID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NumOfQuestion");

                    b.Property<int>("timeperquestion");

                    b.HasKey("RulesID");
                });
        }
    }
}
