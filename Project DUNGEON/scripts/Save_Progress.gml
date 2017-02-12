{
//Call this whenever we need to save the global variables

ini_open("p_save.ini");


save = ds_map_create();

//Save Monster Database
var ce = 0;
while(ce < 35){
    var new_addition = ds_grid_get(global.enemy_database,ce,0);
    ds_map_add(save,ce+1,new_addition);
    ce += 1;
}

//Save Ending Database
var ce = 0;
var ee = 36;
while(ce < 16){
    var new_addition = ds_grid_get(global.ending_database,0,ce);
    ds_map_add(save,ee,new_addition);
    ce += 1;
    ee += 1;
}


//Save High Score
ds_map_add(save,52,global.high_score);
//Save Ad status
ds_map_add(save,"pd_ads",global.ads);

//Save options
var sf = global.show_floor;
var st = global.show_text;
var an = global.animate;
var dd = global.damage_display;
var ld = global.level_display;
var v  = global.volume;
var t = global.tutorial;

ds_map_add(save,54,sf);
ds_map_add(save,55,st);
ds_map_add(save,56,an);
ds_map_add(save,57,dd);
ds_map_add(save,58,ld);
ds_map_add(save,59,v);
ds_map_add(save,"tutorial",t);


//Encrypt the File
ds_map_secure_save(save,"p_save.ini");

ds_map_destroy(save);


ini_close();


}
