{

var php = Dungeon.player_1.HP * 1.0;
var pmhp = Dungeon.player_1.MAX_HP * 1.0;
var ppercent = round(php/pmhp * 100.00);

if(ppercent == 100){
    return true;
}
else{
    return false;
}

}
