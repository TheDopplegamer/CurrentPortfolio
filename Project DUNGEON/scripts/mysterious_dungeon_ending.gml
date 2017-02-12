{
//If we fought nothing, simply explored all 4 route
if(ds_list_size(win_list) == 0){
    var n = 0;
    var found_standard = false;
    var found_chaos = false;
    var found_hell = false;
    var found_treasury = false;
    while(n < ds_list_size(path_list)){
        var cur_tp = ds_list_find_value(path_list,n);
        if(cur_tp == "standard"){found_standard = true;}
        else if(cur_tp == "hell"){found_hell = true;}
        else if(cur_tp == "chaos"){found_chaos = true;}
        else if(cur_tp == "treasury"){found_treasury = true;}
        n += 1;
    }
    
    if(found_standard and found_hell and found_chaos and found_treasury){
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
