
import seaFish from "../assets/icons/sea_fish.png";
import aquarium from "../assets/icons/aquarium.png";
import sushi from "../assets/icons/sushi.png";
import { useEffect, useRef, useState } from "react";
import axios from "axios";
import { Category } from "../types/category";
import { Box, Button, Grid, IconButton, Paper, Stack } from "@mui/material";
import { useTranslation } from "react-i18next";
import { ArrowBack, ArrowForward } from "@mui/icons-material";
import ArrowCircleRightOutlinedIcon from '@mui/icons-material/ArrowCircleRightOutlined';
import ArrowCircleLeftOutlinedIcon from '@mui/icons-material/ArrowCircleLeftOutlined';
import { useNavigate } from "react-router-dom";

export default function Categories(){
    const [category, setCategory] = useState<Category[]>([]);
    const [loading,setLoading] = useState(true);

    const navigate=useNavigate();

    const { t , i18n } = useTranslation();

    useEffect(() => {
        setLoading(true);
        axios.get(`https://localhost:44388/api/Category/GetAllCategories`)
          .then(res => {
            const categories = res.data;
            setCategory(categories);
            setLoading(false);
          })
       

      }, [])

    const scrollRef = useRef<HTMLDivElement | null>(null);

    const scroll = (direction: "left" | "right") => {
    if (scrollRef.current) {
        const scrollAmount = 300; // כמות הגלילה בלחיצה
        scrollRef.current.scrollBy({
        left: direction === "left" ? -scrollAmount : scrollAmount,
        behavior: "smooth", // גלילה חלקה
        });
    }
    };
    
    return (
        <>
        
        <div
          className="spinning-curtain"
          style={{ display: loading ? "flex" : "none" }}
        >
        <div className="loader">
          <img src="https://cdn-icons-gif.flaticon.com/9084/9084427.gif" alt="Loading..." />
        </div>
        </div>
        <div className="col-darkBlue txt-35 txt-bold flex-center mb-30 mt-30" >
                    {t("our_fish")}
        </div>
   
    <Box sx={{ display: "flex", alignItems: "center", width: "100%" ,marginTop: 10}}>
      {/* חץ שמאלה */}
      <IconButton onClick={() => scroll("left")} sx={{ mx: 1 }}>
        < ArrowCircleLeftOutlinedIcon sx={{ fontSize: 40 }} color="primary"/>
      </IconButton>

      {/* תיבת הגלילה */}
      <Box
        ref={scrollRef}
        sx={{
          overflowX: "auto",
          whiteSpace: "nowrap",
          scrollBehavior: "smooth",
          width: "100%",
          height:"100%",
          display: "flex",
          gap: 2,
          "&::-webkit-scrollbar": { display: "none" }, // מסתיר את הסקרול
        }}
      >
        {/* <Stack direction="row" spacing={2} > */}
          {category.map((item) => {
            return <div key={item.categoryId} style={{marginLeft: "20px", marginTop: 30, marginBottom:30,
                padding: "10px",}} onClick={() => { navigate("/category/"+item.categoryId) }}>
                <Paper elevation={24} sx={{ 
                    width: 250,
                     height: 250, 
                     backgroundColor: "rgb(15, 32, 67)",
                     flex: "0 0 auto",
                     display: "flex",
                     flexDirection: "column",  // מוודא שהתמונה והכיתוב יהיו אחד מתחת לשני
                    justifyContent: "center", // ממקם את התוכן במרכז האנכי
                    alignItems: "center",     // ממרכז אופקית
                    textAlign: "center",
                    borderRadius:10,
                    transformOrigin: "center",
                    transition: "transform 0.3s ease-in-out",
                    "&:hover": {
                        transform: "scale(1.2)", // מגדיל את ה-Paper ב-10%
                    },
                    
                    }}>
                    {/* <Button className="mouse-cursor btn-navbar" variant="outlined"  > */}
                    
                    <img 
                    src={item.icon}
                    alt={"categoryName"} 
                    width="70%" 
                    height="70%"
                    style={{ filter: "invert(1)" }}
                    />
                    
                   
                    <div style={{color:"white",fontSize:24,marginTop:3}}>
                    {i18n.language ==="he" ? item.categoryHeName : item.categoryEnName}
                    </div>
                    {/* </Button> */}
                    
                </Paper>
            </div>
          })}
          </Box>

        {/* חץ ימינה */}
        <IconButton onClick={() => scroll("right")} sx={{ mx: 1 }}>
        <ArrowCircleRightOutlinedIcon sx={{ fontSize: 40 }} color="primary"/>
        </IconButton>
        </Box>
       
        </>
    )
} 