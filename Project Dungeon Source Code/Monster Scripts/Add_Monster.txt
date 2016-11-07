{
//////////////////////////////////////////
//Add arguments to the monster data grid
//////////////////////////////////////////
//argument0 - Grid ID
//argument1 - Name
//argument2 - Sprite
//argumemt3 - HP
//argument4 - Strength
//argument5 - Magic
//argument6 - Defense
//argument7 - Res
//argument8 - Luck
//argument9 - Attack Type
////////////////////////////////////////


var cur_x = 0;
var add_to = 0;
var found_it = false;
while(cur_x < ds_grid_width(argument0) and found_it == false){
    if((ds_grid_get(argument0,cur_x,0)) == ""){
        add_to = cur_x;
        found_it = true;
    }
    cur_x += 1;
}



ds_grid_set(argument0,add_to,0,argument1);
ds_grid_set(argument0,add_to,1,argument2);
ds_grid_set(argument0,add_to,2,argument3);
ds_grid_set(argument0,add_to,3,argument4);
ds_grid_set(argument0,add_to,4,argument5);
ds_grid_set(argument0,add_to,5,argument6);
ds_grid_set(argument0,add_to,6,argument7);
ds_grid_set(argument0,add_to,7,argument8);
ds_grid_set(argument0,add_to,8,argument9);
}
