{
if(ani_timer == 0){
    image_index = 0;
    index_timer = 0;
    ani_timer += 1;
}
else if(ani_timer < 30){
    ani_timer += 1;        
}
else if(ani_timer == 30){
    index_timer += 1;
    if(index_timer == 3){
        index_timer = 0;
        image_index += 1;
        if(image_index == 10){
            image_index = 0;
            ani_timer = 0;
            index_timer = 0;
        }
    }   
}
}
