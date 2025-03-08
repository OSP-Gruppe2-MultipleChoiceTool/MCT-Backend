namespace MultipleChoiceTool.Infrastructure.Entities;

/// <summary>
/// Represents the base entity with a unique identifier.
/// </summary>
internal record EntityBase
{
    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    public Guid Id { get; init; }
}
