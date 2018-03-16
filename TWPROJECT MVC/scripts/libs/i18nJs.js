/*
 Copyright (c) 2012-2017 Open Lab
 Permission is hereby granted, free of charge, to any person obtaining
 a copy of this software and associated documentation files (the
 "Software"), to deal in the Software without restriction, including
 without limitation the rights to use, copy, modify, merge, publish,
 distribute, sublicense, and/or sell copies of the Software, and to
 permit persons to whom the Software is furnished to do so, subject to
 the following conditions:

 The above copyright notice and this permission notice shall be
 included in all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
 LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */


function dateToRelative(localTime){
  var diff=new Date().getTime()-localTime;
  var ret="";

  var min=60000;
  var hour=3600000;
  var day=86400000;
  var wee=604800000;
  var mon=2629800000;
  var yea=31557600000;

  if (diff<-yea*2)
    ret ="negli anni ##".replace("##",(-diff/yea).toFixed(0));

  else if (diff<-mon*9)
    ret ="nei mesi ##".replace("##",(-diff/mon).toFixed(0));

  else if (diff<-wee*5)
    ret ="nelle settimane ##".replace("##",(-diff/wee).toFixed(0));

  else if (diff<-day*2)
    ret ="nei giorni ##".replace("##",(-diff/day).toFixed(0));

  else if (diff<-hour)
    ret ="nelle ore ##".replace("##",(-diff/hour).toFixed(0));

  else if (diff<-min*35)
    ret ="in circa un ore";

  else if (diff<-min*25)
    ret ="in circa mezz'ora";

  else if (diff<-min*10)
    ret ="in qualche minuto";

  else if (diff<-min*2)
    ret ="in un paio di minuti";

  else if (diff<=min)
    ret ="adesso";

  else if (diff<=min*5)
    ret ="un paio di minuto fa";

  else if (diff<=min*15)
    ret ="qualche minuto fa";

  else if (diff<=min*35)
    ret ="circa mezz'ora fa";

  else if (diff<=min*75)
    ret ="circa un'ora fa";

  else if (diff<=hour*5)
    ret ="un paio di ore fa";

  else if (diff<=hour*24)
    ret ="## ore fa".replace("##",(diff/hour).toFixed(0));

  else if (diff<=day*7)
      ret = "## giorni fa".replace("##", (diff / day).toFixed(0));

  else if (diff<=wee*5)
      ret = "## settimane fa".replace("##", (diff / wee).toFixed(0));

  else if (diff<=mon*12)
      ret = "## mesi fa".replace("##", (diff / mon).toFixed(0));

  else
      ret = "## anni fa".replace("##", (diff / yea).toFixed(0));

  return ret;
}

//override date format i18n

Date.monthNames = ['Gennaio', 'Febbraio', 'Marzo', 'Aprile', 'Maggio', 'Giugno', 'Luglio', 'Agosto', 'Settembre', 'Ottobre', 'Novembre', 'Dicembre'];
// Month abbreviations. Change this for local month names
Date.monthAbbreviations = ['Gen', 'Feb', 'Mar', 'Apr', 'Mag', 'Gug', 'Lug', 'Ago', 'Set', 'Ott', 'Nov', 'Dec'];
// Full day names. Change this for local month names
Date.dayNames = ['Domenica', 'Lunedì', 'Martedì', 'Mercoledì', 'Giovedì', 'Venerdì', 'Sabato'];
// Day abbreviations. Change this for local month names
Date.dayAbbreviations = ['Dom', 'Lun', 'Mar', 'Mer', 'Gio', 'Ven', 'Sab'];
// Used for parsing ambiguous dates like 1/2/2000 - default to preferring 'American' format meaning Jan 2.
// Set to false to prefer 'European' format meaning Feb 1
Date.preferAmericanFormat = true;

Date.firstDayOfWeek =0;
Date.defaultFormat = "d/M/yyyy";
Date.masks = {
  fullDate:       "EEEE, MMMM d, yyyy",
  shortTime:      "h:mm a"
};
Date.today="Today";

Number.decimalSeparator = ".";
Number.groupingSeparator = ",";
Number.minusSign = "-";
Number.currencyFormat = "###,##0.00";


// modificati per rispecchiare i valori dei dati friIsHoly, satIsHoly, SunIsHoly
// originali
// var millisInWorkingDay =28800000;
// var workingDaysPerWeek =5;

var millisInWorkingDay = 40320000;
var workingDaysPerWeek = 7;

function isHoliday(date) {
  /* dati originali: 
      var friIsHoly =false;
      var satIsHoly =true;
      var sunIsHoly =true;

      Modificati in modo da poter mettere una task anche durante il fine settimana
  */
  var friIsHoly =false;
  var satIsHoly = false;
  var sunIsHoly = false;

  var pad = function (val) {
    val = "0" + val;
    return val.substr(val.length - 2);
  };

  var holidays = "##";

  var ymd = "#" + date.getFullYear() + "_" + pad(date.getMonth() + 1) + "_" + pad(date.getDate()) + "#";
  var md = "#" + pad(date.getMonth() + 1) + "_" + pad(date.getDate()) + "#";
  var day = date.getDay();

  return  (day == 5 && friIsHoly) || (day == 6 && satIsHoly) || (day == 0 && sunIsHoly) || holidays.indexOf(ymd) > -1 || holidays.indexOf(md) > -1;
}

function isWeekEnd(date)
{
    var friIsHoly = false;
    var satIsHoly = true;
    var sunIsHoly = true;

    var pad = function (val) {
        val = "0" + val;
        return val.substr(val.length - 2);
    };

    var holidays = "##";

    var ymd = "#" + date.getFullYear() + "_" + pad(date.getMonth() + 1) + "_" + pad(date.getDate()) + "#";
    var md = "#" + pad(date.getMonth() + 1) + "_" + pad(date.getDate()) + "#";
    var day = date.getDay();

    return (day == 5 && friIsHoly) || (day == 6 && satIsHoly) || (day == 0 && sunIsHoly) || holidays.indexOf(ymd) > -1 || holidays.indexOf(md) > -1;

}

var i18n = {
  YES:                 "Si",
  NO:                  "No",
  FLD_CONFIRM_DELETE:  "conferma eliminazione?",
  INVALID_DATA:        "La data inserita non rispetta il formato del campo.", //"The data inserted are invalid for the field format.",
  ERROR_ON_FIELD:      "Errore nel campo", //"Error on field",
  OUT_OF_BOUDARIES:     "Fuori dal campo di valori consentiti:", //"Out of field admitted values:",
  CLOSE_ALL_CONTAINERS: "Chiudi tutto?", //"close all?",
  DO_YOU_CONFIRM:       "Confermi?", //"Do you confirm?",
  ERR_FIELD_MAX_SIZE_EXCEEDED:      "Raggiunta la dimensione massima del campo", //"Field max size exceeded",
  WEEK_SHORT:  "S.", //"W.",

  FILE_TYPE_NOT_ALLOWED: "Tipo di file non supportato.", //"File type not allowed.",
  FILE_UPLOAD_COMPLETED: "Caricamento file completato.", //"File upload completed.",
  UPLOAD_MAX_SIZE_EXCEEDED: "Superata la dimensione massima del file", //"Max file size exceeded",
  ERROR_UPLOADING: "Errore durante il caricamento", //"Error uploading",
  UPLOAD_ABORTED: "Caricamento annullato", //"Upload aborted",
  DROP_HERE: "Rilasci i file qui", //"Drop files here",

  FORM_IS_CHANGED: "Hai dei dati non salvati nella pagina!", //"You have some unsaved data on the page!",

  PIN_THIS_MENU: "PIN_THIS_MENU",
  UNPIN_THIS_MENU: "UNPIN_THIS_MENU",
  OPEN_THIS_MENU: "OPEN_THIS_MENU",
  CLOSE_THIS_MENU: "CLOSE_THIS_MENU",
  PROCEED: "Procedere?", //"Proceed?",

  PREV: "Precedente", //"Previous",
  NEXT: "Successivo", //"Next",
  HINT_SKIP: "Ho capito, chiudi il suggerimento.", //Got it, close this hint.",

  WANT_TO_SAVE_FILTER: "salva questo filtro", //"save this filter",
  NEW_FILTER_NAME: "nome del nuovo filtro", //"name of the new filter",
  SAVE: "salva", //"Save",
  DELETE: "elimina", //"Delete",
  HINT_SKIP: "Ho capito, chiudi il suggerimento.", //"Got it, close this hint.",

  COMBO_NO_VALUES: "nessun valore disponibile...?", // "no values available...?",

  FILTER_UPDATED: "Filtro aggiornato.", //"Filter updated.",
  FILTER_SAVED: "Filtro salvato correttamente.", //"Filter correctly saved."

};


