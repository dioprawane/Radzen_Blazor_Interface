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

    public async Task<bool> UpdateDialogueAsync2(Dialogue updatedDialogue)
    {
        try
        {
            // Check if the dialogue exists
            var existingDialogue = await _context.Dialogue.FirstOrDefaultAsync(d => d.DCODE == updatedDialogue.DCODE);

            if (existingDialogue == null)
            {
                _logger.LogWarning($"Dialogue with code {updatedDialogue.DCODE} not found.");
                return false;
            }

            // Update the properties only if they are modified
            existingDialogue.DGMACRODESIGNATION = !string.IsNullOrEmpty(updatedDialogue.DGMACRODESIGNATION) ? updatedDialogue.DGMACRODESIGNATION : existingDialogue.DGMACRODESIGNATION;
            existingDialogue.DGNATUREDUBESOIN = !string.IsNullOrEmpty(updatedDialogue.DGNATUREDUBESOIN) ? updatedDialogue.DGNATUREDUBESOIN : existingDialogue.DGNATUREDUBESOIN;
            existingDialogue.DGCADREDACHAT = !string.IsNullOrEmpty(updatedDialogue.DGCADREDACHAT) ? updatedDialogue.DGCADREDACHAT : existingDialogue.DGCADREDACHAT;
            existingDialogue.DGFOURNISSEUR = !string.IsNullOrEmpty(updatedDialogue.DGFOURNISSEUR) ? updatedDialogue.DGFOURNISSEUR : existingDialogue.DGFOURNISSEUR;
            existingDialogue.DGNTIERS = updatedDialogue.DGNTIERS != 0 ? updatedDialogue.DGNTIERS : existingDialogue.DGNTIERS;
            existingDialogue.DGLIBELLEDUMARCHE = !string.IsNullOrEmpty(updatedDialogue.DGLIBELLEDUMARCHE) ? updatedDialogue.DGLIBELLEDUMARCHE : existingDialogue.DGLIBELLEDUMARCHE;
            existingDialogue.DGMASSEBUDGETAIRE = !string.IsNullOrEmpty(updatedDialogue.DGMASSEBUDGETAIRE) ? updatedDialogue.DGMASSEBUDGETAIRE : existingDialogue.DGMASSEBUDGETAIRE;
            existingDialogue.DGDA = !string.IsNullOrEmpty(updatedDialogue.DGDA) ? updatedDialogue.DGDA : existingDialogue.DGDA;
            existingDialogue.DGAXENATIONAL1 = !string.IsNullOrEmpty(updatedDialogue.DGAXENATIONAL1) ? updatedDialogue.DGAXENATIONAL1 : existingDialogue.DGAXENATIONAL1;
            existingDialogue.DGGRANDPROJET = !string.IsNullOrEmpty(updatedDialogue.DGGRANDPROJET) ? updatedDialogue.DGGRANDPROJET : existingDialogue.DGGRANDPROJET;
            existingDialogue.DGNOMPROJET = !string.IsNullOrEmpty(updatedDialogue.DGNOMPROJET) ? updatedDialogue.DGNOMPROJET : existingDialogue.DGNOMPROJET;
            existingDialogue.DGSTATUTPROJETG2PI = !string.IsNullOrEmpty(updatedDialogue.DGSTATUTPROJETG2PI) ? updatedDialogue.DGSTATUTPROJETG2PI : existingDialogue.DGSTATUTPROJETG2PI;
            existingDialogue.DGCODEINITIATIVESDSI = !string.IsNullOrEmpty(updatedDialogue.DGCODEINITIATIVESDSI) ? updatedDialogue.DGCODEINITIATIVESDSI : existingDialogue.DGCODEINITIATIVESDSI;
            existingDialogue.DGOBJECTINITIATIVE = !string.IsNullOrEmpty(updatedDialogue.DGOBJECTINITIATIVE) ? updatedDialogue.DGOBJECTINITIATIVE : existingDialogue.DGOBJECTINITIATIVE;
            existingDialogue.DGCOMPTESBUDGETAIRES = updatedDialogue.DGCOMPTESBUDGETAIRES != 0 ? updatedDialogue.DGCOMPTESBUDGETAIRES : existingDialogue.DGCOMPTESBUDGETAIRES;
            existingDialogue.DGCOMPTESCOMPTABLES = updatedDialogue.DGCOMPTESCOMPTABLES != 0 ? updatedDialogue.DGCOMPTESCOMPTABLES : existingDialogue.DGCOMPTESCOMPTABLES;
            existingDialogue.DGPORTEFEUILLE = !string.IsNullOrEmpty(updatedDialogue.DGPORTEFEUILLE) ? updatedDialogue.DGPORTEFEUILLE : existingDialogue.DGPORTEFEUILLE;
            existingDialogue.DGSOUSPORTEFEUILLE = !string.IsNullOrEmpty(updatedDialogue.DGSOUSPORTEFEUILLE) ? updatedDialogue.DGSOUSPORTEFEUILLE : existingDialogue.DGSOUSPORTEFEUILLE;
            existingDialogue.DGCARACTERISTIQUEDUBESOIN = !string.IsNullOrEmpty(updatedDialogue.DGCARACTERISTIQUEDUBESOIN) ? updatedDialogue.DGCARACTERISTIQUEDUBESOIN : existingDialogue.DGCARACTERISTIQUEDUBESOIN;
            existingDialogue.DGCRITICITE = !string.IsNullOrEmpty(updatedDialogue.DGCRITICITE) ? updatedDialogue.DGCRITICITE : existingDialogue.DGCRITICITE;
            existingDialogue.DGBUDGETINITIALDEMANDE = updatedDialogue.DGBUDGETINITIALDEMANDE != 0 ? updatedDialogue.DGBUDGETINITIALDEMANDE : existingDialogue.DGBUDGETINITIALDEMANDE;
            existingDialogue.DGBUDGETDG1DEMANDE = updatedDialogue.DGBUDGETDG1DEMANDE != 0 ? updatedDialogue.DGBUDGETDG1DEMANDE : existingDialogue.DGBUDGETDG1DEMANDE;
            existingDialogue.DGBUDGETDG2DEMANDE = updatedDialogue.DGBUDGETDG2DEMANDE != 0 ? updatedDialogue.DGBUDGETDG2DEMANDE : existingDialogue.DGBUDGETDG2DEMANDE;
            existingDialogue.DGBUDGETDG3DEMANDE = updatedDialogue.DGBUDGETDG3DEMANDE != 0 ? updatedDialogue.DGBUDGETDG3DEMANDE : existingDialogue.DGBUDGETDG3DEMANDE;
            existingDialogue.DGBUDGETDG4DEMANDE = updatedDialogue.DGBUDGETDG4DEMANDE != 0 ? updatedDialogue.DGBUDGETDG4DEMANDE : existingDialogue.DGBUDGETDG4DEMANDE;
            existingDialogue.DGDEMANDEDEREPORTIDENTIFIE = !string.IsNullOrEmpty(updatedDialogue.DGDEMANDEDEREPORTIDENTIFIE) ? updatedDialogue.DGDEMANDEDEREPORTIDENTIFIE : existingDialogue.DGDEMANDEDEREPORTIDENTIFIE;
            existingDialogue.DGPLANBUDGBIJANVIER = updatedDialogue.DGPLANBUDGBIJANVIER != 0 ? updatedDialogue.DGPLANBUDGBIJANVIER : existingDialogue.DGPLANBUDGBIJANVIER;
            existingDialogue.DGPLANBUDGBR1JUILLET = updatedDialogue.DGPLANBUDGBR1JUILLET != 0 ? updatedDialogue.DGPLANBUDGBR1JUILLET : existingDialogue.DGPLANBUDGBR1JUILLET;
            existingDialogue.DGPLANBUDGBR2NOVEMBRE = updatedDialogue.DGPLANBUDGBR2NOVEMBRE != 0 ? updatedDialogue.DGPLANBUDGBR2NOVEMBRE : existingDialogue.DGPLANBUDGBR2NOVEMBRE;
            existingDialogue.DGNUMEROAB = !string.IsNullOrEmpty(updatedDialogue.DGNUMEROAB) ? updatedDialogue.DGNUMEROAB : existingDialogue.DGNUMEROAB;
            existingDialogue.DGNUMERODB = !string.IsNullOrEmpty(updatedDialogue.DGNUMERODB) ? updatedDialogue.DGNUMERODB : existingDialogue.DGNUMERODB;
            existingDialogue.DGBIAUTORISE = updatedDialogue.DGBIAUTORISE != 0 ? updatedDialogue.DGBIAUTORISE : existingDialogue.DGBIAUTORISE;
            existingDialogue.DGBR1AUTORISE = updatedDialogue.DGBR1AUTORISE != 0 ? updatedDialogue.DGBR1AUTORISE : existingDialogue.DGBR1AUTORISE;
            existingDialogue.DGBR2AUTORISE = updatedDialogue.DGBR2AUTORISE != 0 ? updatedDialogue.DGBR2AUTORISE : existingDialogue.DGBR2AUTORISE;
            existingDialogue.DGNCOMMANDE = !string.IsNullOrEmpty(updatedDialogue.DGNCOMMANDE) ? updatedDialogue.DGNCOMMANDE : existingDialogue.DGNCOMMANDE;
            existingDialogue.DGDATEDEDEBUT = updatedDialogue.DGDATEDEDEBUT != DateTime.MinValue ? updatedDialogue.DGDATEDEDEBUT : existingDialogue.DGDATEDEDEBUT;
            existingDialogue.DGDATEDEFIN = updatedDialogue.DGDATEDEFIN != DateTime.MinValue ? updatedDialogue.DGDATEDEFIN : existingDialogue.DGDATEDEFIN;
            existingDialogue.DGMONTANTCOMMANDE = updatedDialogue.DGMONTANTCOMMANDE != 0 ? updatedDialogue.DGMONTANTCOMMANDE : existingDialogue.DGMONTANTCOMMANDE;
            existingDialogue.DGNENGAGEMENT = !string.IsNullOrEmpty(updatedDialogue.DGNENGAGEMENT) ? updatedDialogue.DGNENGAGEMENT : existingDialogue.DGNENGAGEMENT;
            existingDialogue.DGMONTANTENGAGE = updatedDialogue.DGMONTANTENGAGE != 0 ? updatedDialogue.DGMONTANTENGAGE : existingDialogue.DGMONTANTENGAGE;
            existingDialogue.DGREALISE = updatedDialogue.DGREALISE != 0 ? updatedDialogue.DGREALISE : existingDialogue.DGREALISE;
            existingDialogue.DGGA486ANNEEN1 = !string.IsNullOrEmpty(updatedDialogue.DGGA486ANNEEN1) ? updatedDialogue.DGGA486ANNEEN1 : existingDialogue.DGGA486ANNEEN1;
            existingDialogue.DGGA486ANNEEN2 = !string.IsNullOrEmpty(updatedDialogue.DGGA486ANNEEN2) ? updatedDialogue.DGGA486ANNEEN2 : existingDialogue.DGGA486ANNEEN2;
            existingDialogue.DGGA486ANNEEN3 = !string.IsNullOrEmpty(updatedDialogue.DGGA486ANNEEN3) ? updatedDialogue.DGGA486ANNEEN3 : existingDialogue.DGGA486ANNEEN3;
            existingDialogue.DGGA486ANNEEN4 = !string.IsNullOrEmpty(updatedDialogue.DGGA486ANNEEN4) ? updatedDialogue.DGGA486ANNEEN4 : existingDialogue.DGGA486ANNEEN4;
            existingDialogue.DGBUDGPREVN1 = updatedDialogue.DGBUDGPREVN1 != 0 ? updatedDialogue.DGBUDGPREVN1 : existingDialogue.DGBUDGPREVN1;
            existingDialogue.DGBUDGPREVN2 = updatedDialogue.DGBUDGPREVN2 != 0 ? updatedDialogue.DGBUDGPREVN2 : existingDialogue.DGBUDGPREVN2;
            existingDialogue.DGBUDGPREVN3 = updatedDialogue.DGBUDGPREVN3 != 0 ? updatedDialogue.DGBUDGPREVN3 : existingDialogue.DGBUDGPREVN3;
            existingDialogue.DGBUDGPREVN4 = updatedDialogue.DGBUDGPREVN4 != 0 ? updatedDialogue.DGBUDGPREVN4 : existingDialogue.DGBUDGPREVN4;
            existingDialogue.DGCOMMENTAIRES = !string.IsNullOrEmpty(updatedDialogue.DGCOMMENTAIRES) ? updatedDialogue.DGCOMMENTAIRES : existingDialogue.DGCOMMENTAIRES;
            existingDialogue.DGANNEE = updatedDialogue.DGANNEE != 0 ? updatedDialogue.DGANNEE : existingDialogue.DGANNEE;
            existingDialogue.DGSERIEDEDONNEES = !string.IsNullOrEmpty(updatedDialogue.DGSERIEDEDONNEES) ? updatedDialogue.DGSERIEDEDONNEES : existingDialogue.DGSERIEDEDONNEES;

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

    public async Task<int> GetNewDialogueCodeAsync()
    {
        try
        {
            var maxCode = await _context.Dialogue.MaxAsync(d => d.DCODE);
            return maxCode + 1;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while generating new dialogue code.");
            return -1; // Handle appropriately in the caller
        }
    }

    public async Task<bool> AddDialogueAsync(Dialogue dialogue)
    {
        try
        {
            _context.Dialogue.Add(dialogue);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Added new dialogue with code {dialogue.DCODE}.");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding new dialogue.");
            return false;
        }
    }

    public void DetachEntity(Dialogue dialogue)
    {
        _context.Entry(dialogue).State = EntityState.Detached;
    }

    public async Task<bool> UpdateDialoguesManyAsync(string field, string currentValue, string newValue)
    {
        try
        {
            var dialoguesToUpdate = _context.Dialogue.AsQueryable();

            switch (field)
            {
                case "DGMONTANTCOMMANDE":
                    if (decimal.TryParse(currentValue, out decimal currentDecimal) && decimal.TryParse(newValue, out decimal newDecimal))
                    {
                        dialoguesToUpdate = dialoguesToUpdate.Where(d => d.DGMONTANTCOMMANDE == currentDecimal);
                        foreach (var dialogue in dialoguesToUpdate)
                        {
                            dialogue.DGMONTANTCOMMANDE = newDecimal;
                        }
                    }
                    break;
                case "DGREALISE":
                    if (decimal.TryParse(currentValue, out decimal currentRealise) && decimal.TryParse(newValue, out decimal newRealise))
                    {
                        dialoguesToUpdate = dialoguesToUpdate.Where(d => d.DGREALISE == currentRealise);
                        foreach (var dialogue in dialoguesToUpdate)
                        {
                            dialogue.DGREALISE = newRealise;
                        }
                    }
                    break;
                case "DGNTIERS":
                    if (int.TryParse(currentValue, out int currentInt) && int.TryParse(newValue, out int newInt))
                    {
                        dialoguesToUpdate = dialoguesToUpdate.Where(d => d.DGNTIERS == currentInt);
                        foreach (var dialogue in dialoguesToUpdate)
                        {
                            dialogue.DGNTIERS = newInt;
                        }
                    }
                    break;
                // Ajoutez des cases pour d'autres champs si nécessaire
            }


            await _context.SaveChangesAsync();
            _logger.LogInformation($"Updated {dialoguesToUpdate.Count()} dialogues for field {field}.");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating dialogues.");
            return false;
        }
    }






}
