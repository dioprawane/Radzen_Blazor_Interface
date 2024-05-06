using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // Assurez-vous d'ajouter la directive using pour le logging
using DialogueDeGestion.Controllers; // Remplacez YourAppName par le nom de votre namespace si nécessaire
using DialogueDeGestion.Models; // Assurez-vous que le namespace est correct pour vos modèles

public class DataService
{
    private readonly AppDbContext _context;
    private readonly ILogger<DataService> _logger; // Ajoutez ceci pour le logging

    public DataService(AppDbContext context, ILogger<DataService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Dialogue>> GetAllDialoguesAsync()
    {
        var dialogues = await _context.Dialogue.ToListAsync();
        _logger.LogInformation($"Loaded {dialogues.Count} dialogues."); // Loggez le nombre de dialogues chargés
        return dialogues;
    }


    // Nouvelle méthode pour récupérer un dialogue par code
    public async Task<Dialogue> GetDialogueByCodeAsync(int code)
    {
        try
        {
            var dialogue = await _context.Dialogue.FirstOrDefaultAsync(d => d.DCODE == code);
            if (dialogue == null)
            {
                _logger.LogWarning($"Dialogue with code {code} not found.");
            }
            return dialogue;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching dialogue by code.");
            return null;
        }
    }

    // Method to update the dialogue entity
    public async Task<bool> UpdateDialogueAsync(Dialogue updatedDialogue)
    {
        try
        {
            // Check if the dialogue exists
            var existingDialogue = await _context.Dialogue
                .FirstOrDefaultAsync(d => d.DCODE == updatedDialogue.DCODE);

            if (existingDialogue == null)
            {
                _logger.LogWarning($"Dialogue with code {updatedDialogue.DCODE} not found.");
                return false;
            }

            // Update the properties
            existingDialogue.DGMACRODESIGNATION = updatedDialogue.DGMACRODESIGNATION;
            existingDialogue.DGNATUREDUBESOIN = updatedDialogue.DGNATUREDUBESOIN;
            existingDialogue.DGCADREDACHAT = updatedDialogue.DGCADREDACHAT;
            // Update other relevant properties similarly

            // Mark the entity as modified and save changes
            _context.Entry(existingDialogue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Updated dialogue with code {updatedDialogue.DCODE}.");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating dialogue.");
            return false;
        }
    }

}
