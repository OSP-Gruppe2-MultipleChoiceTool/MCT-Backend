using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Infrastructure.Entities;

namespace MultipleChoiceTool.Infrastructure.Databases;

internal abstract class BaseDbContext<T> : DbContext
    where T : DbContext
{
    protected BaseDbContext(DbContextOptions<T> options) 
        : base(options)
    {
    }

    public virtual DbSet<QuestionaireEntity> Questionaires { get; set; } = null!;

    public virtual DbSet<QuestionaireLinkEntity> QuestionaireLinks { get; set; } = null!;

    public virtual DbSet<StatementSetEntity> StatementSets { get; set; } = null!;

    public virtual DbSet<StatementEntity> Statements { get; set; } = null!;

    public virtual DbSet<StatementTypeEntity> StatementTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<QuestionaireEntity>(questionaire =>
        {
            questionaire.HasKey(questionaire => questionaire.Id);

            questionaire.HasMany(questionaire => questionaire.StatementSets)
                .WithOne(statementSet => statementSet.Questionaire)
                .HasForeignKey(statementSet => statementSet.QuestionaireId)
                .HasPrincipalKey(questionaire => questionaire.Id);

            questionaire.HasMany(questionaire => questionaire.QuestionaireLinks)
                .WithOne(questionaireLink => questionaireLink.Questionaire)
                .HasForeignKey(questionaireLink => questionaireLink.QuestionaireId)
                .HasPrincipalKey(questionaire => questionaire.Id);
        });

        modelBuilder.Entity<QuestionaireLinkEntity>(questionaireLink =>
        {
            questionaireLink.HasKey(questionaireLink => questionaireLink.Id);
        });

        modelBuilder.Entity<StatementEntity>(statement =>
        {
            statement.HasKey(statement => statement.Id);
        });

        modelBuilder.Entity<StatementSetEntity>(statementSet =>
        {
            statementSet.HasKey(statementSet => statementSet.Id);

            statementSet.HasMany(statementSet => statementSet.Statements)
                .WithOne(statement => statement.StatementSet)
                .HasForeignKey(statement => statement.StatementSetId)
                .HasPrincipalKey(statementSet => statementSet.Id);
        });

        modelBuilder.Entity<StatementTypeEntity>(statementType =>
        {
            statementType.HasKey(statementType => statementType.Id);

            statementType.HasMany(statementType => statementType.StatementSets)
                .WithOne(statementSet => statementSet.StatementType)
                .HasForeignKey(statementSet => statementSet.StatementTypeId)
                .HasPrincipalKey(statementType => statementType.Id);
        });
    }
}
