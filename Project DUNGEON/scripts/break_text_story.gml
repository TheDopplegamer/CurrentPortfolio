{
//Takes a string from a library description, then adds new lines where needed

var text = argument0;

//The number of lines this text has, and when to cap it
var line_total = 0;
var line_limit = 9;
var second_page = false;


//Determine how long the string is, and where it ends
var len = string_length(text);
var over = len-1;


var word_start = 1;

var word_num = 0;

//Generate an array of words
var l = 1;
while(l <= len){
    var check = string_char_at(text,l);
    if(check == " "){
        word[word_num] = string_copy(text,word_start,(l-word_start));
        word_num += 1;
        word_start = l + 1;        
    }
    else if(l == len){
        word[word_num] = string_copy(text,word_start,(l+1-word_start));
        word_num += 1;
    }
    l += 1;
}

//Insert the words into an empty string one by one, making sure to add a new line when over a certain width
var l = 0;
var new_text = "";
var new_text_2 = "";

while(l < word_num){
    if(second_page == false){
        if(l > 0){var test_text = new_text + " " + word[l];}
        else{var test_text = word[l];}
        var st = test_text;
        var test_width = string_width(st);
        if(test_width > 134){
            if(line_total == line_limit - 1){
                second_page = true;
                new_text_2 = word[l];    
            }
            else{
                new_text = new_text + "#" + word[l];    
                line_total += 1;
            } 
        }
        else{new_text = test_text;}
    }
    else{
        var test_text = new_text_2 + " " + word[l];
        var st = test_text;
        var test_width = string_width(st);
        var test_width = string_width(test_text);   
        if(test_width > 134){new_text_2 = new_text_2 + "#" + word[l];}
        else{new_text_2 = test_text;}
    }
    l += 1;
}



sp1 = new_text;
sp2 = new_text_2;


}
