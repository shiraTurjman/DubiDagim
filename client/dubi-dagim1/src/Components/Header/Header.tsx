
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { Link, Outlet, useNavigate } from 'react-router-dom';
import Logo from '../../img/logo.png'
import '../Header/Header.css'
import { IconButton, Menu, MenuItem } from '@mui/material';
import { AccountCircle } from '@mui/icons-material';
import React from 'react';
import '../Header/Header.css';

export default function Header()
{

    const _navigate = useNavigate();
    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);
    const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };

    const singUp=()=>{
        _navigate("/SingUp");
    }
    return(
        <>
        <div className="navdar">
        <Navbar expand="lg" className="bg-body-tertiary float-right " >
        <Container>
            <Navbar.Brand>
                <img 
                src={Logo}
                width="60"
                height="60"
                className="d-inline-block align-top"
                alt="logo"></img>
                
            </Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto ">
                <Nav.Link as={Link} to="Home">בית</Nav.Link>
                <Nav.Link >אודותינו</Nav.Link>
                <NavDropdown title="הדגים שלנו" id="basic-nav-dropdown">
                    {/* לולאה של קטגוריות  */}
                <NavDropdown.Item href="#action/3.1">דגים טריים</NavDropdown.Item>
                <NavDropdown.Item href="#action/3.2">
                    דגים קפואים
                </NavDropdown.Item>
                <NavDropdown.Item href="#action/3.3">טחונים ומעושנים</NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item href="#action/3.4">
                    Separated link
                </NavDropdown.Item>
                </NavDropdown>
            </Nav>
            
            </Navbar.Collapse>
            <div>
              <IconButton
                id="basic-button"
                aria-controls={open ? 'basic-menu' : undefined}
                aria-haspopup="true"
                aria-expanded={open ? 'true' : undefined}
                onClick={handleClick}
                style={{ color: "#fbfbfb !important" }}
              >
                <AccountCircle color="primary" />

              </IconButton>

              <Menu
                id="basic-menu"
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                MenuListProps={{
                  'aria-labelledby': 'basic-button',
                }}
              >
                <MenuItem onClick={handleClose}>userName</MenuItem>
                <MenuItem >התחברות</MenuItem>
                <MenuItem onClick={singUp}>הרשמה</MenuItem>
                {/* onClick={toLogout} */}
              </Menu>
            </div>
        </Container>

        </Navbar>
        </div>

        <Outlet></Outlet>
        </>
    )
}