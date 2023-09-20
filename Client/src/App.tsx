import "./App.css";
import Header from "./components/header/Header";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Platforms from "./pages/platforms/Platforms";
import Home from "./pages/home/Home";
import Cryptocurrencies from "./pages/cryptocurrencies/Cryptocurrencies";
import TradesTracker from "./pages/tradesTracker/TradesTracker";
import { store } from "./redux/store";
import { Provider } from "react-redux";
import Login from "./pages/login/Login";
import Registration from "./pages/registration/Registration";
import CryptoTracker from "./pages/cryptoTracker/CryptoTracker";
import NotFoundPage from "./pages/notFoundPage/NotFoundPage";
import OtcCRM from "./pages/otcCRM/OtcCRM";
import OtcCRMMessages from "./pages/otcCRM/otcCRMMessages/OtcCRMMessages";
import OtcCrmAccounting from "./pages/otcCRM/otcCrmAccounting/OtcCrmAccounting";

const App = () => {
  return (
    <Provider store={store}>
      <Router>
        <div className="App">
          <Header />
          <div className="wrapper">
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/platforms" element={<Platforms />} />
              <Route path="/cryptocurrencies" element={<Cryptocurrencies />} />
              <Route path="/tradesTracker" element={<TradesTracker />} />
              <Route path="/cryptoTracker" element={<CryptoTracker />} />
              <Route path="/login" element={<Login />}></Route>
              <Route path="/registration" element={<Registration />}></Route>
              <Route path="/otc_crm" element={<OtcCRM />}>
                <Route path="messages" element={<OtcCRMMessages />} />
                <Route path="accounting" element={<OtcCrmAccounting />} />
                <Route path="deals" element={<h1>My Deals</h1>} />
              </Route>
              <Route path="*" element={<NotFoundPage />}></Route>
            </Routes>
          </div>
        </div>
      </Router>
    </Provider>
  );
};

export default App;
