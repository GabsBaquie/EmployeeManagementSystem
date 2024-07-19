# EmployeeManagementSystem

Cette application est conçue pour lire des informations sur les employés à partir d’un fichier JSON, les désérialiser en objets appropriés, effectuer des calculs et afficher les résultats. L’application prend en charge différents types d’employés : temps plein, temps partiel et contractuels.

## Table des Matières

    1.	[Structure du Projet] (#structure-du-projet)
    2.	[Classes et Méthodes] (#classes-et-méthodes)
    3.	[Utilisation] (#utilisation)
    4.	[Réflexion] (#réflexion)
    5.	[Références] (#références)

## Structure du Projet

Le projet se compose des composants suivants :

    •	`Program` : Le point d’entrée de l’application.
    •	`Employee` : Une classe abstraite représentant un employé.
    •	`FullTimeEmployee` : Une classe dérivée représentant un employé à temps plein.
    •	`PartTimeEmployee` : Une classe dérivée représentant un employé à temps partiel.
    •	`Contractor` : Une classe dérivée représentant un contractuel.
    •	`EmployeeConverter` : Un convertisseur JSON personnalisé pour désérialiser des objets `Employee` à partir de JSON.

## Classes et Méthodes

### Program

La classe `Program` contient la méthode `Main` qui est le point d’entrée de l’application. Elle effectue les étapes suivantes :

    1.	Lit le fichier JSON contenant les données des employés.
    2.	Vérifie si le fichier JSON est vide.
    3.	Désérialise les données JSON en une liste d’objets `Employee`.
    4.	Effectue des requêtes LINQ pour filtrer et calculer les données des employés.
    5.	Affiche les résultats dans la console.

### Employee

La classe `Employee` est une classe abstraite qui définit les propriétés et les méthodes communes à tous les types d’employés. Elle contient les propriétés suivantes :

    •	`Id` : L’identifiant unique de l’employé.
    •	`Name` : Le nom de l’employé.
    •	`GetAnnualCost()` : Une méthode abstraite qui retourne le coût annuel de l’employé.

### FullTimeEmployee

Une classe dérivée de `Employee` représentant un employé à temps plein avec les propriétés et méthodes suivantes :

    •	`AnnualSalary` : Un décimal représentant le salaire annuel de l’employé.
    •	`GetAnnualCost()` : Retourne le salaire annuel.

### PartTimeEmployee

Une classe dérivée de `Employee` représentant un employé à temps partiel avec les propriétés et méthodes suivantes :

    •	`HourlyRate` : Un décimal représentant le taux horaire de l’employé.
    •	`HoursWorked` : Un entier représentant le nombre d’heures travaillées.
    •	`GetAnnualCost()` : Retourne le coût total calculé comme HourlyRate * HoursWorked.

### Contractor

Une classe dérivée de Employee représentant un contractuel avec les propriétés et méthodes suivantes :

    •	`ContractAmount` : Un décimal représentant le montant du contrat.
    •	`GetAnnualCost()` : Retourne le montant du contrat.

### EmployeeConverter

Un convertisseur JSON personnalisé pour désérialiser des objets `Employee` à partir de JSON. Il effectue les étapes suivantes :

    1.	Analyse les données JSON.
    2.	Détermine le type d’employé en fonction de la propriété `Type`.
    3.	Désérialise les données JSON en la classe dérivée appropriée de `Employee`.

## Utilisation

    1. Assurer que le fichier JSON `employees.json` est disponible et contient les données des employés.
    2. Compiler et exécuter l’application.
    3. L’application lira le fichier JSON, désérialisera les données, effectuera des calculs et affichera les résultats dans la console.

## Réflexion

L’application est conçue pour gérer plusieurs types d’employés et calculer leurs coûts annuels. Voici quelques points clés pris en compte lors de la conception et de l’implémentation :

    1.	**Polymorphisme** : L’utilisation d’une classe de base abstraite `Employee` et de classes dérivées permet une gestion flexible des différents types d’employés.
    2.	**Désérialisation JSON** : Le convertisseur JSON personnalisé `EmployeeConverter` simplifie le processus de désérialisation en déterminant le type correct d’employé au moment de l’exécution.
    3.	**Requêtes LINQ** : LINQ est utilisé pour filtrer et calculer les données, rendant le code plus lisible et efficace.
    4.	**Gestion des erreurs** : L’application vérifie si le fichier JSON est vide et gère les types d’employés non pris en charge, fournissant des messages d’erreur clairs.

## Références

    1.	[Documentation Microsoft sur la Sérialisation JSON] (https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-6-0)
    2.	[Documentation Microsoft sur LINQ] (https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
    3.	[Tutoriel LINQ] (https://www.tutorialsteacher.com/linq/linq-tutorials)
    4.	[Tutoriel Polymorphisme] (https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/object-oriented/polymorphism)
    5.	[Tutoriel Gestion des Erreurs] (https://www.tutorialsteacher.com/csharp/csharp-exception-handling)
