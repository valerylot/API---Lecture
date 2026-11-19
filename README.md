//Valery Lot
//11/18/2026
//Challenge #2 Actors API Crud
//What we did: Building off of the API lecture, we added an Actors section. We created a Model, Repository, Service, and Controller. We also made sure to migrate and update the database, as it already existed with Movies, but we wanted Actors in it as well. We made sure all the CRUD functions work, and even made sure that a user cannot add an Actor to the database if it already exists.
//Peer Review Name: Callen Thomason
//Review: GetAll and GetById work as intended, but I would create an error message for when the user is not found. Ex: "Actor with id {id} could not be found". 

- Your validation is not currently working on the AddActor. I can add actors with the same name, and no matter what actor I add I am getting an error message that the actor already exists. I believe it is because you are creating the actor on line 43, then doing the check to see if they exist. Swap the order and it should work fine. Do the check, then create the actor. 

- Update works. Delete also works. I woud also consider adding an error message when the id is not found on the delete also. Just for user convinence. 

- Code is well organized and easy to find. 