const signOut = (e, navigate) => {
    e.preventDefault();
    localStorage.removeItem("token");
    navigate("/login");
}

export default signOut;