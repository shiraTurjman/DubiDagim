import { useState } from "react";
import { Dialog, DialogTitle, DialogContent, DialogActions, Button, Typography, TextField, Select, MenuItem, Grid } from "@mui/material";
import { useTranslation } from "react-i18next";
import { Item } from "../types/item";

interface AddToCartDialogProps {
    open: boolean;
    onClose: () => void;
    item: Item;
}

export default function AddToCartDialog({ open, onClose, item }: AddToCartDialogProps) {
    const { t, i18n } = useTranslation();
    const [cutStyle, setCutStyle] = useState("");
    const [quantity, setQuantity] = useState(1);
    const [notes, setNotes] = useState("");

    const handleAddToCart = () => {
        console.log({ item, cutStyle, quantity, notes });
        onClose();
    };

    return (
        <Dialog open={open} onClose={onClose} maxWidth="md" className="mt-30">
            <DialogTitle>{t("add_to_cart")}</DialogTitle>
            <DialogContent>
                <Grid container spacing={2} alignItems="flex-start">
                    
                    {/* צד ימין - תמונה ופרטים */}
                    <Grid item xs={12} sm={5} display="flex" flexDirection="column" alignItems="center">
                        <img 
                            src={item.images ? `data:image/jpeg;base64,${item.images}` : "/placeholder.jpg"} 
                            alt={item.itemEnName} 
                            style={{ width: "100%", maxWidth: 250, borderRadius: 10 }} 
                        />
                        <Typography variant="body2" mt={2}>{item.details}</Typography>
                    </Grid>

                    {/* צד שמאל - פרטים, בחירות וכפתור */}
                    <Grid  item 
                        xs={12} 
                        sm={5}
                        display="flex" 
                        flexDirection="column" 
                        alignItems="flex-start" 
                        justifyContent="flex-start"
                        sx={{ gap: 1, maxWidth: 250 }}>
                        <Typography variant="h6">{i18n.language === "he" ? item.itemHeName : item.itemEnName}</Typography>
                        <Typography variant="h6">₪{item.price}</Typography>

                        {/* בחירת צורת חיתוך */}
                        <Typography variant="body2" mt={2}>{t("cut_style")}</Typography>
                        <Select fullWidth value={cutStyle} onChange={(e) => setCutStyle(e.target.value)} size="small" 
                            sx={{ maxWidth: 200 }}>
                            <MenuItem value="Whole">{t("whole")}</MenuItem>
                            <MenuItem value="Fillet">{t("fillet")}</MenuItem>
                            <MenuItem value="Slices">{t("slices")}</MenuItem>
                        </Select>

                        {/* בחירת כמות */}
                        <Typography variant="body2" mt={2}>{t("quantity")}</Typography>
                        <TextField 
                            type="number" 
                             
                            value={quantity} 
                            onChange={(e) => setQuantity(Number(e.target.value))} 
                            inputProps={{ min: 1 }} 
                            size="small" 
                            sx={{ maxWidth: 200 }}
                        />

                        {/* תיבת הערות */}
                        <Typography variant="body2" mt={2}>{t("notes")}</Typography>
                        <TextField 
                            fullWidth 
                             
                            rows={3} 
                            value={notes} 
                            onChange={(e) => setNotes(e.target.value)} 
                            inputProps={{ maxLength: 100 }} 
                            size="small" 
                            sx={{ maxWidth: 200 }}
                        />
                    </Grid>
                </Grid>
            </DialogContent>

            {/* כפתור הוספה לעגלה */}
            <DialogActions sx={{ justifyContent: "flex-start" }}>
                <Button 
                    variant="contained" 
                    color="primary" 
                    sx={{ borderRadius: "20px",mt: 2, alignSelf: "flex-start" }} 
                    onClick={handleAddToCart}
                >
                    {t("add_to_cart")}
                </Button>
            </DialogActions>
        </Dialog>
    );
}
