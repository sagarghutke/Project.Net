import { Outlet } from "react-router-dom";
import HomePage from "./FinalHomePageFunctional";
import Search from "./FinalSearch";
//import NavigationBar from './Navbar';
import  Navigation  from './FinalNavBar';

export default function Home() {
    return (
      <div>
        <Navigation/>
        <Outlet/>
      </div>
    )
  }