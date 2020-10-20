import React from 'react'
import tw from 'twin.macro'

const Container = tw.div`border-orange-300 
  grid h-screen grid-cols-default grid-rows-default
`
const SideBar = tw.div`border-blue-300 hidden
  row-span-3 row-start-1 sm:block
`
const Main = tw.div`border-green-300 border
  col-span-2  sm:col-start-2 row-start-2
`
const Header = tw.header`border-red-300 border
  col-span-2 sm:col-start-2
`

const Layout = ({ aside, header, children }) => (
  <Container>
    <Header>{header()}</Header>
    <SideBar>{aside()}</SideBar>
    <Main>{children}</Main>
  </Container>
)

export default Layout
