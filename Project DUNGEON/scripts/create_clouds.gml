{
//Creates a cloud for the endless transition and gives it a speed and coordinates

//Find the first cloud to be empty
var found = false;
var impossible = false;
var c = 0;
while(found == false){
    if(cloud[c] == false){found = true;}
    else{
        c += 1;
        if(c >= num_of_clouds){
            impossible = true;
            found = true;
        }
    }
} 

if(!impossible){
    cloud[c] = true;
    cloud_x[c] = -100;
    cloud_y[c] = irandom_range(0,170);
    cloud_spd[c] = irandom_range(1,2);
    cloud_index[c] = irandom_range(0,4);
}

}
