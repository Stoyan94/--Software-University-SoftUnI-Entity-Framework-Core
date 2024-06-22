﻿
using MiniORM;
using MiniORM.App.Entities;

//Summary
//This code snippet demonstrates creating a ChangeTracker for Department entities, modifying the original entities, 
//and verifying that the ChangeTracker maintains separate copies of these entities. 
//The ReferenceEquals method confirms that the entities tracked by the ChangeTracker are indeed different objects from the originals.
var departments = new Department[] { 
    new Department { Id = 1, Name = "First"}, 
    new Department { Id = 2, Name = "Second" } };

var changeTracker = new ChangeTracker<Department>(departments);

foreach (var (original, copy) in departments.Zip(changeTracker.AllEntities))
{
    original.Id = -1;
    Console.WriteLine(ReferenceEquals(original, copy));
}

//Explanation of Key Points

//ChangeTracker Initialization:
//When the ChangeTracker is initialized with the departments array, 
//    it probably creates internal copies of these entities to track changes. 
//    The AllEntities property of ChangeTracker likely returns these copies.

//Zip Method:
//The Zip method combines two sequences (the original departments and the entities tracked by ChangeTracker) into a single sequence of tuples. 
//    Each tuple contains an element from each sequence at the same position.

//ReferenceEquals:
//ReferenceEquals checks if the two references (original and copy) point to the same object. 
//    Since the ChangeTracker typically holds copies of the original entities, this should return false.