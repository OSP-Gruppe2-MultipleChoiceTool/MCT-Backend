using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;
using RazorLight;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the export of a questionnaire to HTML.
/// </summary>
internal class ExportQuestionaireToHtmlCommandHandler : IRequestHandler<ExportQuestionaireToHtmlCommand, string?>
{
    private const string QuestionaireTemplate = "MultipleChoiceTool.Service.Templates.QuestionaireTemplate";

    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
    private readonly RazorLightEngine _razorLightEngine;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExportQuestionaireToHtmlCommandHandler"/> class.
    /// </summary>
    /// <param name="questionaireReadRepository">The repository to read questionnaires from.</param>
    public ExportQuestionaireToHtmlCommandHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;

        _razorLightEngine = new RazorLightEngineBuilder()
            .UseEmbeddedResourcesProject(typeof(ExportQuestionaireToHtmlCommandHandler).Assembly)
            .UseMemoryCachingProvider()
            .Build();
    }

    /// <summary>
    /// Handles the request to export a questionnaire to HTML.
    /// </summary>
    /// <param name="request">The request containing the questionnaire ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the HTML string if successful; otherwise, null.</returns>
    public async Task<string?> Handle(ExportQuestionaireToHtmlCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, true, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        return await _razorLightEngine.CompileRenderAsync(QuestionaireTemplate, questionaire);
    }
}
