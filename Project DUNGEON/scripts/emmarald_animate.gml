{
ani_timer += 1;
if(ani_timer == 15){
    image_index = 1;
}
else if(ani_timer == 25){
    image_index = 2;
}
else if(ani_timer == 40){
    image_index = 3;
}
else if(ani_timer == 50){
    image_index = 0;
    ani_timer = 0;
}
}
