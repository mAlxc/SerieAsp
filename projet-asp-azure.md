				                 _         ____     ______      
				                / \      / ____|   |   __ \
				               /   \     | (___    |  |__) |
				              /  _  \    \____ \   |  ____/
				             /  / \  \    ____) |  |  |
				            /__/   \__\  |_____/   |__|



# Projet ASP Core MVC / Azure

Vous allez faire un projet complet utilisant les technolgies ASP MVC Core et Azure.

# I- Sujet
Le sujet est libre de choix mais devra être validé par le formateur.

# II- Obligations

## Application Web

L'application web devra être créée en ASP.Net Core MVC 6.
Elle devra donner l'accès à une application web standard et exposer des WEB API en Rest.

## MVC

Vous devez mettre en place le système MVC en respectant les conventions.
Les modèles doivent être obligatoirement dans un projet séparé.
La partie "privée" de l'application sera accessible par authentification en utilisant Identity ou une identification externe via Owin [aide](https://docs.microsoft.com/fr-fr/aspnet/core/fundamentals/owin).
Vous pouvez utilisé automapper pour la gestion des viewmodels [aide](https://dotnetcoretutorials.com/2017/09/23/using-automapper-asp-net-core/)

## Tests unitaires

Un projet de test unitaire devra être réalisé pour la partie MVC avec xUnit. [aide](https://docs.microsoft.com/fr-fr/dotnet/core/testing/unit-testing-with-dotnet-test)

## Base de données

Base de données SQL Server ou MySQL accessible via Entity Core.
La base de données doit être optimisée (clés primaires, clés étrangères, index, taille des champs ...) et sera générée via des migrations (code first).

## Web API

Les Web Api peuvent être dans le projet principal ou dans un projet séparé.
La partie Web API est protégé par un accès sécurisé sous forme de jeton (OAuth 2) [aide](https://www.jerriepelser.com/blog/authenticate-oauth-aspnet-core-2/)
Vous devrez réaliser la doc de l'API avec SwaggerUI [aide](https://swagger.io/swagger-ui/)

## Hébergement

L'hébergement de l'application se fera sous Azure.
Vous allez créer une machine virtuelle (Windows ou Debian) sur laquelle sera hébergé l'application web et la base de données.
La base de données de dev sera elle hébergée directement sur une instance Azure (pas de bdd locale).

## App client
Vous développerez une  application "client" qui attaquera les Web API.
Cette application peut être soit en web (angular ou reactJS) soit mobile (xamarin, android, ios, reactNative ou ionic).
Elle permettra juste de faire une consultation des données.
Elle aura un accès sécurisé.

# Groupes et fonctionnement

Le projet est a développé en groupe de 4 personnes.
Tous les groupes seront définis en cours, sous la supervision de l'enseignant. Les groupes s'enregistrent avec un nom de groupe ainsi que les noms de leurs membres.

Toute inscription est définitive.  Les étudiants ne sont pas autorisés, par la suite, à changer de groupe.

Au sein d'un groupe, les étudiants se répartiront les tâches pour le projet, de façon équitable.  Il est explicitement exigé que chaque membre consacre au moins 50% de son travail à du développement technique. Du code de test est acceptable, tant qu'il ne constitue pas l'intégralité de la réalisation technique du membre du groupe.

Les étudiants sont encouragés (mais pas obligés) à mettre en place un système de contrôle des sources de type Git ou équivalent, afin d'affecter et partager efficacement les fichiers de codes et autres composants numériques du projet (fichiers sources, descripteurs de déploiement, documents de recherche, cas d'utilisation, suites de tests, etc.).

# Soutenance et rendu

La soutenance aura lieux le Jeudi 12 Avril.
C'est une soutenance informelle mais la tenue vestimentaire doit être adaptée.
Les horaires de passage sont définis pour chaque groupe.
Toute absence à la soutenance entrainera un 0 (ZERO) pour le membre du groupe.

Les rendus doivent figurer sur un seul compte par groupe.
Le rendu s'effectu via un repos GIT ou SVN. L'adresse du rendu est envoyé par mail.
Le mail de rendu est vincent.leclerc@ingesup.com
Les fichiers rendus doivent contenir
  - L'arborescence du projet, immédiatement exploitable après création des bases de données et exécution des migrations.</li>
  - Un AUTHORS.TXT listant les membres du groupe (prénom, nom), à raison d'un par ligne.  Il liste ensuite les responsabilités effectives de chacun dans le groupe.
Le sujet du mail doit contenir votre section ainsi que le nom du projet.
Les fichiers rendus peuvent aussi comprendre: 
  - Des documents de recherche créés pour le projet et fournissant plus de détails pour l'enseignant.
Pour tout autre type de fichier, veuillez demander à l'enseignant si son inclusion est appropriée.
