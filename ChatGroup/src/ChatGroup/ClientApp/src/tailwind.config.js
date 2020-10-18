module.exports = {
  dark: 'media',
  experimental: {
    darkModeVariant: true
  },
  purge: [],
  theme: {
    extend: {
      fontFamily: {
        sans: ['Noto Sans', 'system-ui', 'sans-serif']
      }
    }
  },
  variants: {
    opacity: ['responsive', 'hover', 'focus', 'dark']
  },
  plugins: []
}
