{
//Make Sure the store is checked
if(!store_checked){
    //Check the store if it's available to confirm ad status
    if(iap_status() == iap_status_available){
        store_checked = true;
        var store_contents = ds_map_create();
        var purchase_id = ds_map_find_value(global.p_map, "index");     
        iap_purchase_details(purchase_id,store_contents);
        var p_status = ds_map_find_value(store_contents,"status");
        //If the app is purchases, remove ads
        if(p_status == iap_purchased){
            global.ads = 1;
        }
        //If the app is failed, canceled, or refunded, set ads
        if(p_status == iap_failed or p_status == iap_canceled or p_status == iap_refunded){
            global.ads = 1;
        }
        ds_map_destroy(store_contents);
    }
    Save_Progress();
}


}
