import React from 'react'
import tw from 'twin.macro'

const Container = tw.div`inline-grid border-4 border-orange-300 `

const Layout = ({ aside }) => (
  <Container>
    <h1>Hello</h1>
  </Container>
)

export default Layout
