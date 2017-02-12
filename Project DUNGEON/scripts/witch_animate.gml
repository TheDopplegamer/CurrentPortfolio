{
ani_timer += 1;
if(ani_timer == 66){
    image_index = 1;
}
else if(ani_timer == 72){
    image_index = 2;
}
else if(ani_timer == 80){
    image_index = 3;
}
else if(ani_timer == 86){
    image_index = 0;
    ani_timer = 0;
}

}
