{
//////////////////////////////////////////////////////////////////////////////////////////
//Selects and appropriate enemy to spawn from the grid, for chaos, that could be anything
/////////////////////////////////////////////////////////////////////////////////////////


var range_min = 0;
var range_max = num_of_monsters-1;


//Run chance to force spawn slime if prayed to slime statue
if(slime_prayed == true){
    var force_slime = irandom_range(1,4);
    if(force_slime == 1){
        return (irandom_range(0,4));    
    }
}


var rand_index = irandom_range(range_min,range_max);
return rand_index;


}
