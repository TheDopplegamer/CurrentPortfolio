{
//Creates a random group of clouds
var new_cloud = irandom_range(5,7);

var c = 0;
while(c < new_cloud){
    cloud[c] = true;
    cloud_x[c] = irandom_range(20,200);
    cloud_y[c] = irandom_range(10,150);
    cloud_index[c] = irandom_range(0,4);
    cloud_spd[c] = irandom_range(1,2);
    c += 1;    
}

}
