module.exports = {
  experimental: {
    darkModeVariant: true
  },
  theme: {
    extend: {
      fontFamily: {
        sans: ['Noto Sans', 'system-ui', 'sans-serif']
      },
      gridTemplateColumns: {
        default: '20rem 1fr'
      },
      gridTemplateRows: {
        default: '3rem 1fr'
      }
    }
  },
  dark: 'class',
  variants: {
    opacity: ['responsive', 'hover', 'focus', 'dark']
  },
  plugins: []
}
