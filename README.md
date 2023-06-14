# VoitureExpress
# VoitureExpress

VoitureExpress est une application de gestion de r�parations de voitures. Elle permet aux utilisateurs de g�rer les informations sur les voitures et les r�parations effectu�es sur ces voitures.

## Fonctionnalit�s

- Affichage de la liste des voitures enregistr�es dans le syst�me.
- Ajout, modification et suppression de voitures.
- Affichage de la liste des r�parations effectu�es sur une voiture donn�e.
- Ajout, modification et suppression de r�parations.
- Recherche de voitures par marque, mod�le ou finition.
- Authentification des utilisateurs avec r�les administrateurs.

## Pr�requis

Avant de pouvoir ex�cuter l'application VoitureExpress, assurez-vous d'avoir les �l�ments suivants install�s :

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version X.X.X)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) (version X.X.X)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (version X.X.X)

## Structure du projet

- `Program.cs` : Le point d'entr�e de l'application.
- `Startup.cs` : La configuration de l'application et l'injection de d�pendances.
- `Controllers/` : Les contr�leurs de l'application pour la gestion des routes et des actions.
- `Models/` : Les mod�les de donn�es utilis�s dans l'application.
- `Data/` : Les classes de contexte et les migrations pour la gestion de la base de donn�es.
- `Views/` : Les vues de l'application pour l'affichage des informations.
- `wwwroot/` : Les fichiers statiques tels que les feuilles de style CSS et les images.

## Configuration

1. Clonez le d�p�t Git de VoitureExpress sur votre machine locale.
2. Ouvrez le projet dans votre �diteur de code.
3. Configurez la cha�ne de connexion � votre base de donn�es SQL Server dans le fichier `appsettings.json`.
4. Ouvrez une console de commande et acc�dez au r�pertoire racine du projet.
5. Ex�cutez la commande `dotnet ef database update` pour appliquer les migrations et cr�er la base de donn�es.
6. Ex�cutez la commande `dotnet run` pour d�marrer l'application.

## Contribuer

Les contributions � l'am�lioration de VoitureExpress sont les bienvenues! Si vous souhaitez contribuer, veuillez suivre les �tapes suivantes :

1. Fork du d�p�t VoitureExpress.
2. Cr�ez une branche pour vos modifications : `git checkout -b my-feature`.
3. Effectuez les modifications n�cessaires et committez-les : `git commit -m 'Add some feature'`.
4. Push vers la branche principale : `git push origin my-feature`.
5. Soumettez une demande de pull avec vos modifications.

## Auteurs

- Anna D�vi Purmah

## License

Ce projet est sous licence MIT. Consultez le fichier `LICENSE` pour plus d'informations.

---

