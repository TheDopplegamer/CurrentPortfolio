{
if(ani_timer == 0){
    ani_timer = 1;
    image_index = 0;
    timer_limit = irandom_range(20,45);
    ani_2 = 0;
}
else if(ani_2 >= timer_limit){
    ani_timer += 1;
    if(ani_timer == 3){
        ani_timer = 1;
        image_index += 1;
        if(image_index == 4){
            ani_timer = 0; 
            image_index = 0;   
        }
    }
}
ani_2 += 1;







}
