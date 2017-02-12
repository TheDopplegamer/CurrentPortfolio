{
if(Dungeon.player_dead == true){
    if(killer == "Dark Lord" or killer == "Marquis de Chaos" or killer == "Throne of Avarice"){
        if(ds_list_size(run_list) == 0){
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
else{
    return false;
}
}
