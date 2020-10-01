import React from 'react'
import useProfileData from './../hooks/useProfileData'
import tw from 'twin.macro'

const Container = tw.div`container w-full justify-center flex flex-wrap mx-auto px-2 pt-8 lg:pt-16 mt-16`
const Section = tw.section`w-full lg:w-2/3`
const SectionHeadline = tw.h1`font-bold break-normal text-gray-700 px-2 text-xl mt-12 mb-0 lg:mt-0 md:text-2xl text-center`
const SectionDescription = tw.p`text-gray-700 mt-0 mb-12 px-2 text-sm tracking-tight text-center`

const Card = tw.div`py-8 mt-6 lg:mt-0 rounded shadow bg-white rounded-lg`
const CardHeadline = tw.h2`mx-8 font-bold break-normal text-gray-700 px-2 text-xl mb-0 md:text-2xl text-left`
const CardDescription = tw.p`mx-8 text-gray-700 mt-0 mb-12 px-2 text-sm tracking-tight`
const CardItem = tw.div`mx-8 lg:flex mb-6 lg:items-center lg:mr-12`
const CardItemLeft = tw.div`w-1/4`
const CardItemRight = tw.div`w-3/4`
const CardItemLabel = tw.span`text-gray-600 font-semibold md:text-left text-sm mb-3 md:mb-0 pr-4 uppercase`
const CardItemValue = tw.span`w-full px-4 h-10 rounded-lg`
const Line = tw.hr`bg-gray-300 my-8 border-0 h-px`

export default () => {
  const { profileList } = useProfileData()
  console.log(profileList)

  return (
    <Container>
      <Section>
        <SectionHeadline>PersonalInfo</SectionHeadline>
        <SectionDescription>
          Basic info, like your name and photo
        </SectionDescription>
        <Card>
          <CardHeadline>Profile</CardHeadline>
          <CardDescription>
            Changes will be reflected to every services
          </CardDescription>
          <Line />
          {profileList.map((item, index) => (
            <div key={index}>
              <CardItem>
                <CardItemLeft>
                  <CardItemLabel>{item.name}</CardItemLabel>
                </CardItemLeft>
                <CardItemRight>
                  <CardItemValue>
                    {item.value ? item.value : '[not set]'}
                  </CardItemValue>
                </CardItemRight>
              </CardItem>
              <Line />
            </div>
          ))}
        </Card>
      </Section>
    </Container>
  )
}
