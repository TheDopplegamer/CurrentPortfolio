{
//Takes a large number argument then converts it to individual digits in a array, for use by endless results

var num = argument0;

var digits = 1;
var found = false;

//Determine number of digits
while(!found){
    var group = power(10,digits);
    if(num < group){found = true;}
    else{digits += 1;}
}

var n = digits;

num_digits = digits;

var a = 0;

//Starting with the left-most digit, determine the digits of the number
while(n > 0){

    //First, make sure the digit is not 0
    
    if(num < power(10,n-1)){
        num_array[a] = 0;
        a += 1;
    }
    else{
        var d = 1;
        while(d < 10){
            var sub = d * (power(10,n-1));
            var check_total = num-sub;
            if(check_total < (power(10,n-1))){
                num_array[a] = d;
                num = check_total;
                a += 1;
                d = 10;
            }
            else{d += 1;}
        }
    }    
    n -= 1;
}






}
