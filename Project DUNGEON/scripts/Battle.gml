{
///////////////////////////////////////////////////////////////////////////////////////
//Manages the flow of battle, run by the battlefield object every step during a battle
///////////////////////////////////////////////////////////////////////////////////////

if(battle_phase == "goto 2"){battle_phase = "attack 2";}

//Check for specials
Special();
//Check for Fleeing
Flee();
//Player 1 attacks
Attack_1();
//Player 2 attacks
Attack_2();
//Display Results
Results();


}
