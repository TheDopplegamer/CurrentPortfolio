{
//Checks if the only thing in the run list is the dark lord
var slime_found = false;

if(ds_list_size(run_list) == 1){
    var check = ds_list_find_value(run_list,0);
    if(check == "Dark Lord" or check == "Marquis de Chaos" or check == "Throne of Avarice"){
        return true;
    }
    else{
        return false;
    }
}
else{
    return false;
}


}
