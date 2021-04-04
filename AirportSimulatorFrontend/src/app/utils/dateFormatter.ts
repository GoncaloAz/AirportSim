
export function DateFormatter(date : Date){

    var year = date.getFullYear();
    var month = date.getMonth()+1;
    var day = date.getDate();
    var hour = date.getHours();
    var minutes = date.getMinutes();
    var seconds = date.getSeconds();

    var sYear;
    var sMonth;
    var sDay;
    var sHour;
    var sMinutes;
    var sSeconds;

    //Date
    if(year < 10){
        sYear="0"+year.toString();
    }else{
        sYear=year.toString();
    }
    if(month < 10){
        sMonth="0"+month.toString();
    }else{
        sMonth=month.toString();
    }
    if(day < 10){
        sDay="0"+day.toString();
    }else{
        sDay=day.toString();
    }

    //Time
    if(hour < 10){
        sHour="0"+hour.toString();
    }else{
        sHour=hour.toString();
    }if(minutes < 10){
        sMinutes="0"+minutes.toString();
    }else{
        sMinutes=minutes.toString();
    }if(seconds < 10){
        sSeconds="0"+seconds.toString();
    }else{
        sSeconds=seconds.toString();
    }

    var formatted = sYear +"-"+sMonth+"-"+sDay+"T"+
               sHour+":"+sMinutes+":"+sSeconds;

    return formatted;
}
