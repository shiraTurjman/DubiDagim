import { Paper } from "@mui/material"
import { useTranslation } from "react-i18next"
import { useNavigate } from "react-router-dom"


export default function Editing() {
    const { t } = useTranslation()
    const navigate = useNavigate();
    return (
        <>
            <div className="col-darkBlue txt-35 txt-bold flex-center mb-30 mt-30" >
                {t("editing")}
            </div>
            <div key={1} style={{
                marginLeft: "20px", marginTop: 30, marginBottom: 30,
                padding: "10px",
            }} onClick={() => { navigate("edititem") }}>
                <Paper elevation={24} sx={{
                    width: 250,
                    height: 100,
                    backgroundColor: "rgb(15, 32, 67)",
                    flex: "0 0 auto",
                    display: "flex",
                    flexDirection: "column",  // מוודא שהתמונה והכיתוב יהיו אחד מתחת לשני
                    justifyContent: "center", // ממקם את התוכן במרכז האנכי
                    alignItems: "center",     // ממרכז אופקית
                    textAlign: "center",
                    borderRadius: 10,
                    transformOrigin: "center",
                    transition: "transform 0.3s ease-in-out",
                    "&:hover": {
                        transform: "scale(1.2)", // מגדיל את ה-Paper ב-10%
                    },

                }}>
                    <div style={{ color: "white", fontSize: 24, marginTop: 3 }}>
                        {t("items")}
                    </div>
                </Paper>
            </div>
            <div key={1} style={{
                marginLeft: "20px", marginTop: 30, marginBottom: 30,
                padding: "10px",
            }} onClick={() => { navigate("editCategory") }}>
                <Paper elevation={24} sx={{
                    width: 250,
                    height: 100,
                    backgroundColor: "rgb(15, 32, 67)",
                    flex: "0 0 auto",
                    display: "flex",
                    flexDirection: "column",  // מוודא שהתמונה והכיתוב יהיו אחד מתחת לשני
                    justifyContent: "center", // ממקם את התוכן במרכז האנכי
                    alignItems: "center",     // ממרכז אופקית
                    textAlign: "center",
                    borderRadius: 10,
                    transformOrigin: "center",
                    transition: "transform 0.3s ease-in-out",
                    "&:hover": {
                        transform: "scale(1.2)", // מגדיל את ה-Paper ב-10%
                    },

                }}>
                    <div style={{ color: "white", fontSize: 24, marginTop: 3 }}>
                        {t("categories")}
                    </div>
                </Paper>
            </div>
        </>
    )
}