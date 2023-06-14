# VoitureExpress
# VoitureExpress

VoitureExpress est une application de gestion de réparations de voitures. Elle permet aux utilisateurs de gérer les informations sur les voitures et les réparations effectuées sur ces voitures.

## Fonctionnalités

- Affichage de la liste des voitures enregistrées dans le système.
- Ajout, modification et suppression de voitures.
- Affichage de la liste des réparations effectuées sur une voiture donnée.
- Ajout, modification et suppression de réparations.
- Recherche de voitures par marque, modèle ou finition.
- Authentification des utilisateurs avec rôles administrateurs.

## Prérequis

Avant de pouvoir exécuter l'application VoitureExpress, assurez-vous d'avoir les éléments suivants installés :

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version X.X.X)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) (version X.X.X)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (version X.X.X)

## Structure du projet

- `Program.cs` : Le point d'entrée de l'application.
- `Startup.cs` : La configuration de l'application et l'injection de dépendances.
- `Controllers/` : Les contrôleurs de l'application pour la gestion des routes et des actions.
- `Models/` : Les modèles de données utilisés dans l'application.
- `Data/` : Les classes de contexte et les migrations pour la gestion de la base de données.
- `Views/` : Les vues de l'application pour l'affichage des informations.
- `wwwroot/` : Les fichiers statiques tels que les feuilles de style CSS et les images.

## Configuration

1. Clonez le dépôt Git de VoitureExpress sur votre machine locale.
2. Ouvrez le projet dans votre éditeur de code.
3. Configurez la chaîne de connexion à votre base de données SQL Server dans le fichier `appsettings.json`.
4. Ouvrez une console de commande et accédez au répertoire racine du projet.
5. Exécutez la commande `dotnet ef database update` pour appliquer les migrations et créer la base de données.
6. Exécutez la commande `dotnet run` pour démarrer l'application.

## Contribuer

Les contributions à l'amélioration de VoitureExpress sont les bienvenues! Si vous souhaitez contribuer, veuillez suivre les étapes suivantes :

1. Fork du dépôt VoitureExpress.
2. Créez une branche pour vos modifications : `git checkout -b my-feature`.
3. Effectuez les modifications nécessaires et committez-les : `git commit -m 'Add some feature'`.
4. Push vers la branche principale : `git push origin my-feature`.
5. Soumettez une demande de pull avec vos modifications.

## Auteurs

- Anna Dévi Purmah

## License

Ce projet est sous licence MIT. Consultez le fichier `LICENSE` pour plus d'informations.

---

