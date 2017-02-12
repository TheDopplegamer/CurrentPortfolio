{
//Handle movement of clouds for endless transition


var c = 0;
while(c < num_of_clouds){
    if(cloud[c] == true){
        cloud_x[c] += cloud_spd[c];
        if(cloud_x[c] >= room_width){
            cloud[c] = false;
        } 
    }
    c += 1;
}


}
