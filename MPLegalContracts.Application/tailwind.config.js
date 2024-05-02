/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{vue,html,js}"],
  theme: {
    screens:{
      sm: "376px",
      md: '1024px',
      lg: "1440px",
      xl: "1920px"
    },
    extend: {
      fontFamily: {
        'Montserrat': ['Montserrat', 'sans-serif'],
        'SpaceGrotesk' : ['Space Grotesk', 'sans-serif'],
        'Poppins': ['Poppins', 'sans-serif']
      }
    },
  },
  plugins: [],
}