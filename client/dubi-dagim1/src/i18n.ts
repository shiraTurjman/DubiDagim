import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import LanguageDetector from "i18next-browser-languagedetector";

// ייבוא קובצי התרגום
import translationEN from "./locales/EnTranslation.json";
import translationHE from "./locales/HeTranslation.json";


const resources = {
    en: { translations: translationEN },
    he: { translations: translationHE }
  };

i18n
  .use(initReactI18next)
  .use(LanguageDetector)
  .init({
    resources,
    lng: localStorage.getItem("language") || "en", 
    // have a common namespace used around the full app
    ns: ["translations"],
    fallbackLng: "en", // אם השפה אינה זמינה
    interpolation: {
      escapeValue: false, // לא נחוץ ב-React
    },
    debug: true,
   
    defaultNS: "translations",
    keySeparator: false,
    
  });

i18n.on("languageChanged", (lng) => {
localStorage.setItem("language", lng);
});

export default i18n;
