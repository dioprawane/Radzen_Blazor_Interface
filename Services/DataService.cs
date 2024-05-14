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

    public async Task<bool> UpdateDialogueAsyncV2(int dcode, string macroDesignation, string natureDuBesoin, string cadreDAchat, string fournisseur, int nTiers, string libelleDuMarche)
    {
        try
        {
            var existingDialogue = await _context.Dialogue.FirstOrDefaultAsync(d => d.DCODE == dcode);

            if (existingDialogue == null)
            {
                _logger.LogWarning($"Dialogue with code {dcode} not found.");
                return false;
            }

            existingDialogue.DGMACRODESIGNATION = macroDesignation;
            existingDialogue.DGNATUREDUBESOIN = natureDuBesoin;
            existingDialogue.DGCADREDACHAT = cadreDAchat;
            existingDialogue.DGFOURNISSEUR = fournisseur;
            existingDialogue.DGNTIERS = nTiers;
            existingDialogue.DGLIBELLEDUMARCHE = libelleDuMarche;
            // Update other relevant properties similarly

            _context.Entry(existingDialogue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Updated dialogue with code {dcode}.");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating dialogue.");
            return false;
        }
    }


    public async Task<bool> AddUpdatedDialogueAsync(int dcode, string macroDesignation, string natureDuBesoin, string cadreDAchat, string fournisseur, int nTiers, string libelleDuMarche)
    {
        try
        {
            var existingDialogue = await _context.Dialogue.FirstOrDefaultAsync(d => d.DCODE == dcode);

            if (existingDialogue == null)
            {
                _logger.LogWarning($"Dialogue with code {dcode} not found.");
                return false;
            }

            var newDialogue = new Dialogue
            {
                DGMACRODESIGNATION = !string.IsNullOrEmpty(macroDesignation) ? macroDesignation : existingDialogue.DGMACRODESIGNATION,
                DGNATUREDUBESOIN = !string.IsNullOrEmpty(natureDuBesoin) ? natureDuBesoin : existingDialogue.DGNATUREDUBESOIN,
                DGCADREDACHAT = !string.IsNullOrEmpty(cadreDAchat) ? cadreDAchat : existingDialogue.DGCADREDACHAT,
                DGFOURNISSEUR = !string.IsNullOrEmpty(fournisseur) ? fournisseur : existingDialogue.DGFOURNISSEUR,
                DGNTIERS = nTiers != 0 ? nTiers : existingDialogue.DGNTIERS,
                DGLIBELLEDUMARCHE = !string.IsNullOrEmpty(libelleDuMarche) ? libelleDuMarche : existingDialogue.DGLIBELLEDUMARCHE,
                // Copy other properties from existingDialogue if they are not updated
                // You can add more properties here similarly
            };

            _context.Dialogue.Add(newDialogue);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Added new dialogue with code {newDialogue.DCODE}.");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding updated dialogue.");
            return false;
        }
    }

    public async Task DeleteDialogueAsync(int dcode)
    {
        var dialogue = await _context.Dialogue.FirstOrDefaultAsync(d => d.DCODE == dcode);
        if (dialogue != null)
        {
            _context.Dialogue.Remove(dialogue);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Deleted dialogue with code {dcode}.");
        }
        else
        {
            _logger.LogWarning($"Dialogue with code {dcode} not found and cannot be deleted.");
        }
    }

    // Inside DataService.cs

    public async Task AddDialogueAsync(Dialogue newDialogue)
    {
        try
        {
            _context.Dialogue.Add(newDialogue);
            await _context.SaveChangesAsync();
            _logger.LogInformation("New dialogue added successfully with ID: {Id}", newDialogue.DCODE);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding new dialogue");
            throw; // Optionally re-throw to handle the error outside this method
        }
    }


}
