{
//////////////////////////////////////////
//Add arguments to the monster library database
//////////////////////////////////////////
//argument0 - Name
//argument1 - Sprite
//argumemt2 - HP
//argument3 - Strength
//argument4 - Magic
//argument5 - Defense
//argument6 - Res
//argument7 - Luck
//argument8 - Attack Type
//argument9 - Description
////////////////////////////////////////



var see_name = argument0;
var see_sprite = argument1;
var see_hp = argument2;
var see_strength = argument3;
var see_magic = argument4;
var see_defense = argument5;
var see_res = argument6;
var see_luck = argument7;
var see_type = argument8;
var see_description = argument9;

var cur_x = 0;
var add_to = 0;
var found_it = false;
while(cur_x < ds_grid_width(global.enemy_database) and found_it == false){
    if((ds_grid_get(global.enemy_database,cur_x,1)) == ""){
        add_to = cur_x;
        found_it = true;
    }
    else{
        cur_x += 1;
    }
}

ds_grid_set(global.enemy_database,cur_x,1,argument0);
ds_grid_set(global.enemy_database,cur_x,2,argument1);
ds_grid_set(global.enemy_database,cur_x,3,argument2);
ds_grid_set(global.enemy_database,cur_x,4,argument3);
ds_grid_set(global.enemy_database,cur_x,5,argument4);
ds_grid_set(global.enemy_database,cur_x,6,argument5);
ds_grid_set(global.enemy_database,cur_x,7,argument6);
ds_grid_set(global.enemy_database,cur_x,8,argument7);
ds_grid_set(global.enemy_database,cur_x,9,argument8);
ds_grid_set(global.enemy_database,cur_x,10,argument9);

}
