{
ani_timer += 1;
if(ani_timer >= 16){
    if(image_index == 0){
        image_index = 1;
    }
    else{
        image_index = 0;
    }
    ani_timer = 0;
}
}
