# Radzen Blazor Interface

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

Radzen Blazor Interface est une application web utilisant Blazor et Radzen pour la gestion des dialogues de gestion budgétaires de la DSI. Elle permet de consulter, ajouter, modifier et supprimer des entrées dans une base de données. De plus, elle inclut des fonctionnalités pour filtrer les dialogues et exporter les données au format Excel.

## Table des matières

- [Fonctionnalités](#fonctionnalités)
- [Installation](#installation)
- [Usage](#usage)
- [Contribuer](#contribuer)
- [Licence](#licence)
- [Contact](#contact)

## Fonctionnalités

### Gestion des Dialogues

- **Vue des Dialogues** : Affiche une liste de tous les dialogues présents dans la base de données.
- **Ajouter un Dialogue** : Formulaire pour ajouter un nouveau dialogue.
- **Modifier un Dialogue** : Formulaire pour modifier les détails d'un dialogue existant.
- **Supprimer un Dialogue** : Fonction pour supprimer un dialogue avec confirmation.
- **Filtrage des Dialogues** : Filtrer les dialogues affichés par série de données.
- **Exportation en Excel** : Exporter les données affichées au format Excel.

### Navigation

- **Accueil** : Vue d'ensemble de l'application.
- **Ajouter** : Formulaire pour ajouter de nouveaux dialogues.
- **Modifier** : Formulaire pour modifier les dialogues existants.
- **Supprimer** : Vue pour supprimer les dialogues avec confirmation.
- **Sélectionner** : Vue pour sélectionner et filtrer les dialogues.
- **Voir** : Vue détaillée des dialogues.

### Interface Utilisateur

- **Responsive Design** : Interface adaptée aux différents types d'écrans.
- **Utilisation de Radzen** : Composants Radzen pour une interface utilisateur riche et interactive.

## Installation

### Prérequis

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/) (pour les dépendances front-end)

### Étapes d'installation

1. Clonez le repository :

    ```bash
    git clone https://github.com/dioprawane/Radzen_Blazor_Interface.git
    cd Radzen_Blazor_Interface
    ```

2. Restaurez les packages NuGet :

    ```bash
    dotnet restore
    ```

3. Installez les dépendances npm (si nécessaire) :

    ```bash
    npm install
    ```

4. Compilez et lancez l'application :

    ```bash
    dotnet run
    ```

5. Ouvrez votre navigateur et accédez à `https://localhost:5001` pour voir l'application en action.

## Usage

### Ajouter un Dialogue

1. Naviguez vers la page **Add**.
2. Remplissez le formulaire avec les détails du dialogue.
3. Cliquez sur **Save** pour ajouter le nouveau dialogue.

### Modifier un Dialogue

1. Naviguez vers la page **Edit**.
2. Sélectionnez le dialogue à modifier.
3. Mettez à jour les détails et cliquez sur **Save**.

### Supprimer un Dialogue

1. Naviguez vers la page **Delete**.
2. Cliquez sur le bouton **Supprimer** à côté du dialogue à supprimer.
3. Confirmez la suppression dans le popup.

### Filtrer les Dialogues

1. Utilisez la barre de filtre sur la page **Select**.
2. Entrez une série de données pour filtrer les dialogues.

### Exporter les Dialogues en Excel

1. Sur la page **Select**, cliquez sur le bouton **Export to Excel**.
2. Le fichier Excel sera téléchargé automatiquement.

## Contribuer

Les contributions sont les bienvenues ! Pour soumettre une contribution :

1. Forkez le repository.
2. Créez une branche pour votre fonctionnalité (`git checkout -b feature/new-feature`).
3. Commitez vos modifications (`git commit -m 'Add new feature'`).
4. Poussez votre branche (`git push origin feature/new-feature`).
5. Ouvrez une Pull Request.

## Licence

Ce projet est sous licence MIT. Voir le fichier [LICENSE](LICENSE) pour plus de détails.

## Contact

Pour toute question ou suggestion, n'hésitez pas à contacter l'auteur :

- **Nom** : DIOP Serigne Rawane
- **Email** : [serigne-rawane.diop@acoss.fr](mailto:votre.email@example.com)
- **GitHub** : [dioprawane](https://github.com/dioprawane)
# interface_blazor.Net8
