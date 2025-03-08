using Microsoft.EntityFrameworkCore;
using MultipleChoiceTool.Infrastructure.Entities;

namespace MultipleChoiceTool.Infrastructure.Databases;

/// <summary>
/// Base database context class for the application.
/// Implementations of this class are used for generating appropriate migration classes.
/// </summary>
/// <typeparam name="T">The type of the derived DbContext.</typeparam>
internal abstract class BaseDbContext<T> : DbContext
    where T : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseDbContext{T}"/> class.
    /// </summary>
    /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
    protected BaseDbContext(DbContextOptions<T> options) 
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the DbSet for Questionaire entities.
    /// </summary>
    public virtual DbSet<QuestionaireEntity> Questionaires { get; set; } = null!;

    /// <summary>
    /// Gets or sets the DbSet for QuestionaireLink entities.
    /// </summary>
    public virtual DbSet<QuestionaireLinkEntity> QuestionaireLinks { get; set; } = null!;

    /// <summary>
    /// Gets or sets the DbSet for StatementSet entities.
    /// </summary>
    public virtual DbSet<StatementSetEntity> StatementSets { get; set; } = null!;

    /// <summary>
    /// Gets or sets the DbSet for Statement entities.
    /// </summary>
    public virtual DbSet<StatementEntity> Statements { get; set; } = null!;

    /// <summary>
    /// Gets or sets the DbSet for StatementType entities.
    /// </summary>
    public virtual DbSet<StatementTypeEntity> StatementTypes { get; set; } = null!;

    /// <summary>
    /// Configures the context options.
    /// </summary>
    /// <param name="optionsBuilder">A builder used to create or modify options for this context.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Do not use tracking as we are always throwing away our entities and mapping them to models
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    /// <summary>
    /// Configures the model that was discovered by convention from the entity types
    /// exposed in <see cref="DbSet{TEntity}"/> properties on the derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
