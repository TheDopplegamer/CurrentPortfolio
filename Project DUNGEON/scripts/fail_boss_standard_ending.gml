{

//If the player dies to dark lord, run fail boss ending
if(Dungeon.player_dead == true){
    if(killer == "Dark Lord" or killer == "Marquis de Chaos" or killer == "Throne of Avarice"){
        return true;
    }
    else{
        return false;
    }
}
else{
    return false;
}


}
