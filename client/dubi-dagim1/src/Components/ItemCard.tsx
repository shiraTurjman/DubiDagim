import { Button, Card, CardContent, CardMedia, Typography } from "@mui/material";
import {Item} from "../types/item";
import { useTranslation } from "react-i18next";
import { useEffect } from "react";
import Logo from '../img/logo.png';


interface ItemCardProps {
    onPress: (item: Item) => void;
    item: Item;
}

export default function ItemCard(props: ItemCardProps) {

    const {item} = props;
    const { t, i18n } = useTranslation();
    useEffect(() => {
        console.log(item);
    }, []);

    if (!item) return null;

   
    return (
        
    <>{item && <Card sx={{ 
                    maxWidth: 250, 
                    m: 2, 
                    textAlign: "center",
                    backgroundColor: "rgba(255, 255, 255, 0.1)", // שקיפות
                    backdropFilter: "blur(10px)", // טשטוש רקע
                    borderRadius: 3, // פינות עגולות לכרטיס
                    boxShadow: "none" 
                     }}>
            <CardMedia component="img" height="150" image={item.images ? `data:image/jpeg;base64,${item.images}` : Logo} alt={item.itemEnName} sx={{ borderRadius: "10px 10px 0 0" }}/>
            <CardContent sx={{ display: "flex", flexDirection: "column", alignItems: "flex-start" }}>
            <Typography variant="h6">{i18n.language ==="he" ? item.itemHeName : item.itemEnName}</Typography>
            {/* <Typography variant="body2">₪{item.price}</Typography> */}
            <Button variant="contained" color="primary"  onClick={() => props.onPress(item)} 
            sx={{ 
                        mt: 1, 
                        borderRadius: "20px", // פינות עגולות לכפתור
                        alignSelf: "flex-start" // מיקום בצד שמאל
                    }} >
                {t("add_to_cart")}
            </Button>
            </CardContent>
        </Card>}
        
    </>
        )
}