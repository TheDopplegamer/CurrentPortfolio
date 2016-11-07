{
///////////////////////////////////////////////////////////////////////////
//Creates a grid 20 units longer then the endless grid and copies it into it
///////////////////////////////////////////////////////////////////////////

var h = ds_grid_height(global.endless_grid);

var copy = ds_grid_create(2,h);
ds_grid_copy(copy,global.endless_grid);

var new_grid = ds_grid_create(2,h+20);

//Initialize the grid
var nx = 0;
var ny = 0;

while(ny < h+20){
    while(nx < 2){
        ds_grid_set(new_grid,nx,ny,0);
        nx += 1;
    }
    ny += 1;
    nx = 0;
}

//Copy the previous info into the grid
var l = 0;
var w = 0;

while(l < h){
    while(w < 2){
        var entry = ds_grid_get(copy,w,l);
        ds_grid_set(new_grid,w,l,entry);
        w += 1;
    }
    l += 1;
    w = 0;
}

//Done with the copy, destroy it
ds_grid_destroy(copy);

//Destroy the previous endless grid, then replace it with the new grid
ds_grid_destroy(global.endless_grid);

global.endless_grid = ds_grid_create(2,h+20);
ds_grid_copy(global.endless_grid,new_grid);

//Destroy the new grid
ds_grid_destroy(new_grid);



}
