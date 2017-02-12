{

//If the player dies to bomb
if(Dungeon.player_dead == true){
    if(killer == "Bomb"){
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
