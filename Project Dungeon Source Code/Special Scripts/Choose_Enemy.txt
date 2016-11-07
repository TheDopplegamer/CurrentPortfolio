{
//////////////////////////////////////////////////////////
//Selects and appropriate enemy to spawn from the grid, for use by standard paths
//////////////////////////////////////////////////////////
//Dungeon Variables used in this script
//-----------------------------------------
//current_y
//////////////////////////////////////////////////////////


//Based on the random ticket, decide on an index range, then return a random value in that range
if(current_y <= 4){
    var range_min = 0;
    var range_max = 4;
}
else if(current_y <= 8){
    var range_min = 5;
    var range_max = 7;
}
else if(current_y <= 11){
    var range_min = 8;
    var range_max = 10;
}
else if(current_y <= 14){
    var range_min = 11;
    var range_max = 13;
}
else if(current_y <= 17){
    var range_min = 14;
    var range_max = 16;
}
else if(current_y <= 20){
    var range_min = 17;
    var range_max = 18;
}
else if(current_y <= 23){
    var range_min = 19;
    var range_max = 22;
}
else if(current_y <= 26){
    var range_min = 23;
    var range_max = 27;
}
else{
    var range_min = 28;
    var range_max = 30;
}


//Adjust the range parameters based on curve
//Curve of 1 : Lower minumum by 1 tier
if(curve == 1){
    if(range_min == 0){}
    else if(range_min == 5){range_min = 0;}
    else if(range_min == 8){range_min = 5;}
    else if(range_min == 11){range_min = 8;}
    else if(range_min == 14){range_min = 11;}
    else if(range_min == 17){range_min = 14;}
    else if(range_min == 19){range_min = 17;}
    else if(range_min == 23){range_min = 19;}
    else{range_min = 23;}
}
//Curve of 2 : Do nothing

//Curve of 3 : Raise minumum by 1 tier
else if(curve == 3){
    if(range_max == 4)      {range_max = 7;}
    else if(range_max == 7) {range_max = 10;}
    else if(range_max == 10){range_max = 13;}
    else if(range_max == 13){range_max = 16;}
    else if(range_max == 16){range_max = 18;}
    else if(range_max == 18){range_max = 22;}
    else if(range_max == 22){range_max = 27;}
    else{range_max = 30;}
}


//This block is used to force a selection for testing purpouses

if(1 == 0){
var s = 0;
while(s < 100){
    var test_name = ds_grid_get(Dungeon.monster_data,s,0);
    if(test_name == "Diamand"){return s;}
    s += 1;
}
}


//Run chance to force spawn slime if prayed to slime statue
if(slime_prayed == true){
    var force_slime = irandom_range(1,4);
    if(force_slime == 1){
        return (irandom_range(0,4));    
    }
}



//Run chance for secret monster
var secret_chance = irandom_range(3,100);

if(secret_chance == 1){
    var secret_index = irandom_range(44,num_of_monsters-1);
    return secret_index;
}

else{
    var rand_index = irandom_range(range_min,range_max);
    return rand_index;
}
 







}
